using System;
using System.Collections.Generic;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Repositories;

namespace Synergy.Domain.Model
{
    public static class TaskRecurrence
    {
        #region Internal declarations

        private static IList<TaskEntity> _tasks;
        private static DateTime? _dueDate;

        #endregion

        #region Public methods

        public static void EvaluateRecurrence(TaskEntity task)
        {
            if (task.Recurrence.RepeatFrom == RecurrenceRepeatFrom.DateCompleted)
            {
                processRepeatFromDateCompleted(task);
                return;
            }

            switch (task.Recurrence.Type)
            {
                case RecurrenceType.Daily:
                    evaluateDailyRecurrence(task);
                    return;

                case RecurrenceType.Weekly:
                    evaluateWeeklyRecurrence(task);
                    return;

                case RecurrenceType.Monthly:
                    evaluateMonthlyRecurrence(task);
                    return;

                case RecurrenceType.Yearly:
                    evaluateYearlyRecurrence(task);
                    return;

                default:
                    return;
            }
        }

        public static void EvaluateRecurrences()
        {
            evaluateDailyRecurrences();
            evaluateWeeklyRecurrences();
            evaluateMonthlyRecurrences();
            evaluateYearlyRecurrences();
        }

        #endregion

        #region Recurrence repeat from date completed

        private static void processRepeatFromDateCompleted(TaskEntity task)
        {
            if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
            {
                if (task.Recurrence.EndDate < DateTime.Today)
                    return;

                if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                    return;

                if (task.Recurrence.EndDate < task.DueDate.Value.AddDays(task.Recurrence.Interval))
                    return;
            }

            _dueDate = task.CompletedOn.Value.AddDays(1);
            saveTask(task);
        }

        #endregion

        #region Daily recurrences

        private static void evaluateDailyRecurrences()
        {
            var repo = new TaskRepository();
            _tasks = repo.GetRecursiveTasks(RecurrenceType.Daily);
            if (_tasks == null || _tasks.Count == 0)
                return;

            foreach (var task in _tasks)
                evaluateDailyRecurrence(task);
        }

        private static void evaluateDailyRecurrence(TaskEntity task)
        {
            if (!task.Recurrence.Duplicate && task.Status == TaskStatus.Pending)
                return;

            if (task.Recurrence.NewGenerated)
                return;

            if (task.Recurrence.Duplicate && task.Status == TaskStatus.Pending
                    && task.DueDate.Value.Date == DateTime.Today && !task.Recurrence.IsRegenerated)
                return;

            if (task.Recurrence.IsRegenerated)
            {
                if (getDailyRegeneratedDueDate(task) > DateTime.Today
                        && task.Recurrence.StartDate > DateTime.Today)
                {
                    task.Recurrence = null;
                    new Task(task).Save(true);
                    return;
                }

                _dueDate = getDailyRegeneratedDueDate(task);
                saveTask(task);
                return;
            }

            if (task.Recurrence.Interval == -1) //Weekdays (Monday to Saturday)
            {
                if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
                {
                    if (task.Recurrence.EndDate < DateTime.Today.Date)
                        return;

                    if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                        return;
                }

                _dueDate = getDailyWeekdaysDueDate(task);
                saveTask(task);
                return;
            }

            if (task.Recurrence.Interval != -1) //Daily with interval
            {
                if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
                {
                    if (task.Recurrence.EndDate < DateTime.Today)
                        return;

                    if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                        return;

                    if (task.Recurrence.EndDate < task.DueDate.Value.AddDays(task.Recurrence.Interval))
                        return;
                }

                _dueDate = getDailyDueDate(task);
                saveTask(task);
                return;
            }
        }

        private static DateTime? getDailyRegeneratedDueDate(TaskEntity task)
        {
            return task.DueDate.Value.Date > DateTime.Today ? task.DueDate : getDailyDueDate(task);
        }

        private static DateTime? getDailyWeekdaysDueDate(TaskEntity task)
        {
            var dueDate = getDailyDueDate(task).Value;
            return dueDate.DayOfWeek == DayOfWeek.Sunday ? dueDate.AddDays(1) : dueDate;
        }

        private static DateTime? getDailyDueDate(TaskEntity task)
        {
            var date = task.Status == TaskStatus.Pending
                            ? task.DueDate.Value.Date
                            : task.DueDate.Value.AddDays(Math.Abs(task.Recurrence.Interval));

            while (date < DateTime.Today)
                date = date.AddDays(Math.Abs(task.Recurrence.Interval));

            return date;
        }

        #endregion

        #region Weekly recurrences

        private static void evaluateWeeklyRecurrences()
        {
            var repo = new TaskRepository();
            _tasks = repo.GetRecursiveTasks(RecurrenceType.Weekly);
            if (_tasks == null || _tasks.Count == 0)
                return;

            foreach (var task in _tasks)
                evaluateWeeklyRecurrence(task);
        }

        private static void evaluateWeeklyRecurrence(TaskEntity task)
        {
            if (!task.Recurrence.Duplicate && task.Status == TaskStatus.Pending)
                return;

            if (task.Recurrence.NewGenerated)
                return;

            if (task.Recurrence.Duplicate && task.Status == TaskStatus.Pending
                    && task.DueDate.Value.Date == DateTime.Today && !task.Recurrence.IsRegenerated)
                return;

            if (task.Recurrence.IsRegenerated)
            {
                if (getWeeklyRegeneratedDueDate(task) > DateTime.Today
                        && task.Recurrence.StartDate > DateTime.Today)
                {
                    task.Recurrence = null;
                    new Task(task).Save(true);
                    return;
                }

                _dueDate = getWeeklyRegeneratedDueDate(task);
                saveTask(task);
                return;
            }

            if (task.Recurrence.DaysOfWeek != -1) //Weekly with interval
            {
                if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
                {
                    if (task.Recurrence.EndDate < DateTime.Today)
                        return;

                    if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                        return;

                    if (task.Recurrence.EndDate < task.DueDate.Value.AddDays(task.Recurrence.Interval * 7))
                        return;
                }

                _dueDate = getWeeklyDueDate(task);
                saveTask(task);
                return;
            }
        }

        private static DateTime? getWeeklyRegeneratedDueDate(TaskEntity task)
        {
            return task.DueDate.Value.Date > DateTime.Today ? task.DueDate : getWeeklyDueDate(task);
        }

        private static DateTime? getWeeklyDueDate(TaskEntity task)
        {
            var date = task.DueDate.Value.Date;
            if (date < DateTime.Today)
                date = DateTime.Today;

            date = date.AddDays((task.Recurrence.Interval - 1) * 7);

            var count = task.Recurrence.Duplicate && task.Status == TaskStatus.Pending ? 0 : 1;
            for (var i = count; i < 7; i++)
                if (validWeeklyDueDate(task, date, i))
                    return date.AddDays(i);

            return date.AddDays(count * 7);
        }

        private static bool validWeeklyDueDate(TaskEntity task, DateTime date, int days)
        {
            var day = date.AddDays(days).DayOfWeek.ToString();

            if ((task.Recurrence.DaysOfWeek & (int)DaysOfWeek.Sunday) == (int)DaysOfWeek.Sunday && day == DaysOfWeek.Sunday.ToString())
                return true;

            if ((task.Recurrence.DaysOfWeek & (int)DaysOfWeek.Monday) == (int)DaysOfWeek.Monday && day == DaysOfWeek.Monday.ToString())
                return true;

            if ((task.Recurrence.DaysOfWeek & (int)DaysOfWeek.Tuesday) == (int)DaysOfWeek.Tuesday && day == DaysOfWeek.Tuesday.ToString())
                return true;

            if ((task.Recurrence.DaysOfWeek & (int)DaysOfWeek.Wednesday) == (int)DaysOfWeek.Wednesday && day == DaysOfWeek.Wednesday.ToString())
                return true;

            if ((task.Recurrence.DaysOfWeek & (int)DaysOfWeek.Thursday) == (int)DaysOfWeek.Thursday && day == DaysOfWeek.Thursday.ToString())
                return true;

            if ((task.Recurrence.DaysOfWeek & (int)DaysOfWeek.Friday) == (int)DaysOfWeek.Friday && day == DaysOfWeek.Friday.ToString())
                return true;

            if ((task.Recurrence.DaysOfWeek & (int)DaysOfWeek.Saturday) == (int)DaysOfWeek.Saturday && day == DaysOfWeek.Saturday.ToString())
                return true;

            return false;
        }

        #endregion

        #region Monthly recurrences

        private static void evaluateMonthlyRecurrences()
        {
            var repo = new TaskRepository();
            _tasks = repo.GetRecursiveTasks(RecurrenceType.Monthly);
            if (_tasks == null || _tasks.Count == 0)
                return;

            foreach (var task in _tasks)
                evaluateMonthlyRecurrence(task);
        }

        private static void evaluateMonthlyRecurrence(TaskEntity task)
        {
            if (!task.Recurrence.Duplicate && task.Status == TaskStatus.Pending)
                return;

            if (task.Recurrence.NewGenerated)
                return;

            if (task.Recurrence.Duplicate && task.Status == TaskStatus.Pending
                    && task.DueDate.Value.Date == DateTime.Today && !task.Recurrence.IsRegenerated)
                return;

            if (task.Recurrence.IsRegenerated)
            {
                if (getMonthlyRegeneratedDueDate(task) > DateTime.Today
                        && task.Recurrence.StartDate > DateTime.Today)
                {
                    task.Recurrence = null;
                    new Task(task).Save(true);
                    return;
                }

                _dueDate = getMonthlyRegeneratedDueDate(task);
                saveTask(task);
                return;
            }

            if (task.Recurrence.DayOfMonth == -1)
            {
                if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
                {
                    if (task.Recurrence.EndDate < DateTime.Today.Date)
                        return;

                    if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                        return;
                }

                _dueDate = getMonthlyIntervalDueDate(task);
                saveTask(task);
                return;
            }

            if (task.Recurrence.DayOfMonth != -1) //Monthly with interval
            {
                if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
                {
                    if (task.Recurrence.EndDate < DateTime.Today.Date)
                        return;

                    if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                        return;

                    if (task.Recurrence.EndDate < task.DueDate.Value.AddMonths(task.Recurrence.Interval))
                        return;
                }

                _dueDate = getMonthlyDueDate(task);
                saveTask(task);
                return;
            }
        }

        private static DateTime? getMonthlyRegeneratedDueDate(TaskEntity task)
        {
            return task.DueDate.Value.Date > DateTime.Today ? task.DueDate : getMonthlyDueDate(task);
        }

        private static DateTime? getMonthlyIntervalDueDate(TaskEntity task)
        {
            if (task.Recurrence.DayOfWeek == DayOfWeekType.First)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getMonthlyDateTime(task, 1, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getMonthlyDateTime(task, 1, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Sunday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Monday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Tuesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Wednesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Thursday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Friday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Second)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getMonthlyDateTime(task, 2, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getMonthlyDateTime(task, 2, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Sunday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Monday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Tuesday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Wednesday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Thursday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Friday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday, 1);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Third)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getMonthlyDateTime(task, 3, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getMonthlyDateTime(task, 3, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Sunday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Monday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Tuesday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Wednesday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Thursday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Friday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday, 2);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Fourth)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getMonthlyDateTime(task, 4, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getMonthlyDateTime(task, 4, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Sunday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Monday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Tuesday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Wednesday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Thursday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Friday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getMonthlyDateTime(task, 1, (int)DayOfWeek.Saturday, 3);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Last)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getMonthlyLastDateTime(task, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getMonthlyLastDateTime(task, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(-1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Saturday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Sunday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Monday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Tuesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Wednesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Thursday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Friday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getMonthlyLastDateTime(task, (int)DayOfWeek.Saturday);
            }

            return null;
        }

        private static DateTime getMonthlyDateTime(TaskEntity task, int day, int setDay, int addWeeks = 0)
        {
            DateTime date;
            if (task.Status == TaskStatus.Pending)
            {
                date = getValidMonthlyDateTime(task.DueDate.Value.Date, day);
                date = getValidWeeklyDateTime(setDay, addWeeks, date);
            }
            else
            {
                date = getValidMonthlyDateTime(task.DueDate.Value.Date.AddMonths(task.Recurrence.Interval), day);
                date = getValidWeeklyDateTime(setDay, addWeeks, date);
            }

            while (date < DateTime.Today)
            {
                date = getValidMonthlyDateTime(date.AddMonths(task.Recurrence.Interval), day);
                date = getValidWeeklyDateTime(setDay, addWeeks, date);
            }

            return date;
        }

        private static DateTime getMonthlyLastDateTime(TaskEntity task, int setDay)
        {
            if (task.Recurrence.Duplicate && task.DueDate.Value.Date <= DateTime.Today)
                task.DueDate = DateTime.Today;

            var date = new DateTime(task.DueDate.Value.Date.AddMonths(task.Recurrence.Interval).Year,
                            task.DueDate.Value.Date.AddMonths(task.Recurrence.Interval).Month, 1).AddDays(-1);

            return setDay == -1 ? date : date.AddDays((-7 + setDay - (int)date.DayOfWeek) % 7);
        }

        private static DateTime? getMonthlyDueDate(TaskEntity task)
        {
            var date = task.Status == TaskStatus.Pending
                            ? getValidMonthlyDateTime(task.DueDate.Value.Date, task.Recurrence.DayOfMonth)
                            : getValidMonthlyDateTime(task.DueDate.Value.AddMonths(task.Recurrence.Interval), task.Recurrence.DayOfMonth);

            while (date < DateTime.Today)
                date = getValidMonthlyDateTime(date.AddMonths(task.Recurrence.Interval), task.Recurrence.DayOfMonth);

            return date;
        }

        #endregion

        #region Yearly recurrences

        private static void evaluateYearlyRecurrences()
        {
            var repo = new TaskRepository();
            _tasks = repo.GetRecursiveTasks(RecurrenceType.Yearly);
            if (_tasks == null || _tasks.Count == 0)
                return;

            foreach (var task in _tasks)
                evaluateYearlyRecurrence(task);
        }

        private static void evaluateYearlyRecurrence(TaskEntity task)
        {
            if (!task.Recurrence.Duplicate && task.Status == TaskStatus.Pending)
                return;

            if (task.Recurrence.NewGenerated)
                return;

            if (task.Recurrence.Duplicate && task.Status == TaskStatus.Pending
                    && task.DueDate.Value.Date == DateTime.Today && !task.Recurrence.IsRegenerated)
                return;

            if (task.Recurrence.IsRegenerated)
            {
                if (getYearlyRegeneratedDueDate(task) > DateTime.Today
                        && task.Recurrence.StartDate > DateTime.Today)
                {
                    task.Recurrence = null;
                    new Task(task).Save(true);
                    return;
                }

                _dueDate = getYearlyRegeneratedDueDate(task);
                saveTask(task);
                return;
            }

            if (task.Recurrence.DayOfMonth == -1)
            {
                if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
                {
                    if (task.Recurrence.EndDate < DateTime.Today.Date)
                        return;

                    if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                        return;
                }

                _dueDate = getYearlyIntervalDueDate(task);
                saveTask(task);
                return;
            }

            if (task.Recurrence.DayOfMonth != -1) //Yearly with interval
            {
                if (task.Recurrence.RangeType == RecurrenceRangeType.EndByDate)
                {
                    if (task.Recurrence.EndDate < DateTime.Today.Date)
                        return;

                    if (task.Recurrence.EndDate <= task.DueDate.Value.Date)
                        return;

                    if (task.Recurrence.EndDate < task.DueDate.Value.AddYears(1))
                        return;
                }

                _dueDate = getYearlyDueDate(task);
                saveTask(task);
                return;
            }
        }

        private static DateTime? getYearlyRegeneratedDueDate(TaskEntity task)
        {
            return task.DueDate.Value.Date > DateTime.Today ? task.DueDate : getYearlyDueDate(task);
        }

        private static DateTime? getYearlyIntervalDueDate(TaskEntity task)
        {
            if (task.Recurrence.DayOfWeek == DayOfWeekType.First)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getYearlyDateTime(task, 1, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getYearlyDateTime(task, 1, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Sunday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Monday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Tuesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Wednesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Thursday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Friday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Second)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getYearlyDateTime(task, 2, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getYearlyDateTime(task, 2, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Sunday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Monday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Tuesday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Wednesday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Thursday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Friday, 1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday, 1);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Third)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getYearlyDateTime(task, 3, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getYearlyDateTime(task, 3, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Sunday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Monday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Tuesday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Wednesday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Thursday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Friday, 2);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday, 2);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Fourth)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getYearlyDateTime(task, 4, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getYearlyDateTime(task, 4, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Sunday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Monday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Tuesday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Wednesday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Thursday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Friday, 3);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getYearlyDateTime(task, 1, (int)DayOfWeek.Saturday, 3);
            }

            if (task.Recurrence.DayOfWeek == DayOfWeekType.Last)
            {
                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Day)
                    return getYearlyLastDateTime(task, -1);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Weekday)
                {
                    var date = getYearlyLastDateTime(task, -1);
                    return date.DayOfWeek == DayOfWeek.Sunday ? date.AddDays(-1) : date;
                }

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.WeekendDay)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Saturday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Sunday)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Sunday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Monday)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Monday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Tuesday)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Tuesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Wednesday)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Wednesday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Thursday)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Thursday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Friday)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Friday);

                if (task.Recurrence.DayOfWeekIndex == DayOfWeekIndexType.Saturday)
                    return getYearlyLastDateTime(task, (int)DayOfWeek.Saturday);
            }

            return null;
        }

        private static DateTime getYearlyDateTime(TaskEntity task, int day, int setDay, int addWeeks = 0)
        {
            DateTime date;
            if (task.Status == TaskStatus.Pending)
            {
                date = new DateTime(task.DueDate.Value.Date.Year, (int)task.Recurrence.Month, day);
                date = getValidWeeklyDateTime(setDay, addWeeks, date);
            }
            else
            {
                date = new DateTime(task.DueDate.Value.Date.AddYears(1).Year, (int)task.Recurrence.Month, day);
                date = getValidWeeklyDateTime(setDay, addWeeks, date);
            }

            while (date < DateTime.Today)
            {
                date = new DateTime(date.AddYears(1).Year, (int)task.Recurrence.Month, day);
                date = getValidWeeklyDateTime(setDay, addWeeks, date);
            }

            return date;
        }

        private static DateTime getYearlyLastDateTime(TaskEntity task, int setDay)
        {
            if (task.Recurrence.Duplicate && task.DueDate.Value.Date <= DateTime.Today)
                task.DueDate = DateTime.Today;

            var date = new DateTime(task.DueDate.Value.AddYears(1).Year,
                                        (int)task.Recurrence.Month + 1, 1).AddDays(-1);

            return setDay == -1 ? date : date.AddDays((-7 + setDay - (int)date.DayOfWeek) % 7);
        }

        private static DateTime? getYearlyDueDate(TaskEntity task)
        {
            DateTime date;
            if (task.Status == TaskStatus.Pending)
                date = task.Recurrence.IsRegenerated
                           ? new DateTime(task.DueDate.Value.Date.Year,
                                            task.DueDate.Value.Date.Month, task.DueDate.Value.Date.Day)
                           : getValidMonthlyDateTime(new DateTime(task.DueDate.Value.Date.Year,
                                            (int)task.Recurrence.Month, 1), task.Recurrence.Interval);
            else
                date = task.Recurrence.IsRegenerated
                           ? new DateTime(task.DueDate.Value.Date.AddYears(1).Year,
                                            task.DueDate.Value.Date.Month, task.DueDate.Value.Date.Day)
                           : getValidMonthlyDateTime(new DateTime(task.DueDate.Value.Date.AddYears(1).Year,
                                            (int)task.Recurrence.Month, 1), task.Recurrence.Interval);

            while (date < DateTime.Today)
                date = task.Recurrence.IsRegenerated
                           ? new DateTime(date.AddYears(1).Year, date.Month, date.Day)
                           : new DateTime(date.AddYears(1).Year, (int)task.Recurrence.Month, date.Day);

            return date;
        }

        #endregion

        #region Common

        private static void saveTask(TaskEntity task)
        {
            var newTask = getTaskCopy(task);

            if (task.Recurrence.Duplicate)
            {
                task.Recurrence.Duplicate = false;
                task.Recurrence.NewGenerated = true;
                new Task(task).Save(true);
            }

            task = newTask;

            if (task.Recurrence.RangeType == RecurrenceRangeType.Occurrences)
            {
                if (task.Recurrence.Occurences == 0)
                    return;

                task.Recurrence.Occurences--;
            }

            task.DueDate = _dueDate;
            task.StartDate = task.DueDate;
            new Task(task).Save(true);
        }

        private static TaskEntity getTaskCopy(TaskEntity task)
        {
            var newTask = new TaskEntity();
            newTask.Tag = task.Tag;
            newTask.Name = task.Name;
            newTask.Description = task.Description;
            newTask.DescriptionText = task.DescriptionText;
            newTask.ParentId = task.ParentId;
            newTask.EstimatedTime = task.EstimatedTime;
            newTask.CreatedById = task.CreatedById;
            newTask.AssignedById = task.AssignedById;
            newTask.AssignedToId = task.AssignedToId;
            newTask.CcToIds = task.CcToIds;
            newTask.Priority = task.Priority;
            newTask.TypeId = task.TypeId;
            newTask.ProjectId = task.ProjectId;
            newTask.LocationId = task.LocationId;
            newTask.Checklist = getChecklistCopy(task);
            newTask.Recurrence = getRecurrenceCopy(task);
            newTask.Attachments = task.Attachments;
            return newTask;
        }

        private static ChecklistEntity getChecklistCopy(TaskEntity task)
        {
            var checklist = new ChecklistEntity();
            checklist.Id = task.Checklist.Id;
            checklist.Name = task.Checklist.Name;
            checklist.Description = task.Checklist.Description;

            if (checklist.Items != null && checklist.Items.Count == 0)
            {
                foreach (var item in task.Checklist.Items)
                    item.IsDone = false;

                checklist.Items = task.Checklist.Items;
            }

            return checklist;
        }

        private static RecurrenceEntity getRecurrenceCopy(TaskEntity task)
        {
            var recurrence = new RecurrenceEntity();
            recurrence.Type = task.Recurrence.Type;
            recurrence.IsRegenerated = task.Recurrence.IsRegenerated;
            recurrence.Interval = task.Recurrence.Interval;
            recurrence.DaysOfWeek = task.Recurrence.DaysOfWeek;
            recurrence.DayOfMonth = task.Recurrence.DayOfMonth;
            recurrence.DayOfWeek = task.Recurrence.DayOfWeek;
            recurrence.DayOfWeekIndex = task.Recurrence.DayOfWeekIndex;
            recurrence.Month = task.Recurrence.Month;
            recurrence.StartDate = task.Recurrence.StartDate;
            recurrence.RangeType = task.Recurrence.RangeType;
            recurrence.Occurences = task.Recurrence.Occurences;
            recurrence.EndDate = task.Recurrence.EndDate;
            recurrence.Duplicate = task.Recurrence.Duplicate;
            return recurrence;
        }

        private static DateTime getValidWeeklyDateTime(int setDay, int addWeeks, DateTime date)
        {
            date = setDay == -1 ? date : date.AddDays((7 + setDay - (int)date.DayOfWeek) % 7);
            date = date.AddDays(addWeeks * 7);
            return date;
        }

        private static DateTime getValidMonthlyDateTime(DateTime date, int day)
        {
            DateTime result;

            if (day <= 28)
            {
                result = new DateTime(date.Year, date.Month, day);
                return result;
            }

            if (DateTime.TryParse(string.Format("{0}-{1}-{2}", date.Month, day, date.Year), out result))
                return result;

            if (DateTime.TryParse(string.Format("{0}-{1}-{2}", date.Month, day - 1, date.Year), out result))
                return result;

            if (DateTime.TryParse(string.Format("{0}-{1}-{2}", date.Month, day - 2, date.Year), out result))
                return result;

            if (DateTime.TryParse(string.Format("{0}-{1}-{2}", date.Month, day - 3, date.Year), out result))
                return result;

            return date;
        }

        #endregion

        #region Recurrence due date

        public static DateTime? GetRecurrenceDueDate(TaskEntity task)
        {
            if (task.DueDate == null)
                task.DueDate = DateTime.Today;

            #region For Daily

            if (task.Recurrence.Type == RecurrenceType.Daily)
            {
                if (task.Recurrence.IsRegenerated)
                    return getDailyRegeneratedDueDate(task);

                if (task.Recurrence.Interval == -1)
                    return getDailyWeekdaysDueDate(task);

                if (task.Recurrence.Interval != -1)
                    return getDailyDueDate(task);
            }
            #endregion

            #region For Weekly

            if (task.Recurrence.Type == RecurrenceType.Weekly)
            {
                if (task.Recurrence.IsRegenerated)
                    return getWeeklyRegeneratedDueDate(task);

                if (task.Recurrence.DaysOfWeek != -1)
                    return getWeeklyDueDate(task);
            }

            #endregion

            #region For Monthly

            if (task.Recurrence.Type == RecurrenceType.Monthly)
            {
                if (task.Recurrence.IsRegenerated)
                    return getMonthlyRegeneratedDueDate(task);

                if (task.Recurrence.DayOfMonth == -1)
                    return getMonthlyIntervalDueDate(task);

                if (task.Recurrence.DayOfMonth != -1)
                    return getMonthlyDueDate(task);
            }

            #endregion

            #region For Yearly

            if (task.Recurrence.Type == RecurrenceType.Yearly)
            {
                if (task.Recurrence.IsRegenerated)
                    return getYearlyRegeneratedDueDate(task);

                if (task.Recurrence.DayOfMonth == -1)
                    return getYearlyIntervalDueDate(task);

                if (task.Recurrence.DayOfMonth != -1)
                    return getYearlyDueDate(task);
            }

            #endregion

            return null;
        }

        #endregion
    }
}
