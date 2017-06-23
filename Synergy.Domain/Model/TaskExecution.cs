using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.Forms;
using Synergy.Domain.Entities;
using Synergy.Domain.Properties;
using Synergy.Domain.Repositories;

namespace Synergy.Domain.Model
{
    public static class TaskExecution
    {
        #region Constant declarations

        private const string _userCurrentTaskKey = "CurrentTask";
        private const string _taskExecutionsSuffixKey = "Executions";

        #endregion

        #region Set current task

        public static void SetCurrentTask(Task task)
        {
            var currentTaskNr = GetCurrentTaskNr();

            if (task == null)
            {
                if (string.IsNullOrWhiteSpace(currentTaskNr))
                    throw new ValidationException(Resources.SelectTask);

                RemoveCurrentTask(currentTaskNr);
                return;
            }

            if (string.IsNullOrWhiteSpace(currentTaskNr))
            {
                setNewCurrentTask(task);
                return;
            }

            if (currentTaskNr == task.GetTaskNumber())
            {
                RemoveCurrentTask(task.GetTaskNumber());
                return;
            }

            changeCurrentTask(task, currentTaskNr);
        }

        public static string GetCurrentTaskNr(string userId = null)
        {
            var task = GetCurrentTask(userId);
            return task == null ? null : task.GetTaskNumber();
        }

        public static Task GetCurrentTask(string userId = null)
        {
            var currentTaskId = getCurrentTaskId(userId);
            if (currentTaskId == null)
                return null;

            var repo = new TaskRepository();
            var task = repo.GetTaskEntityBy(currentTaskId);
            return task == null ? null : new Task(task);
        }

        private static string getCurrentTaskId(string userId = null)
        {
            var userConfig = UserConfig.GetConfig(_userCurrentTaskKey, userId);
            if (userConfig == null || userConfig.Value == null)
                return null;

            return userConfig.Value.ToString();
        }

        private static void setNewCurrentTask(Task task)
        {
            var dialogResult = MessageBoxUtil.GetConfirmationYesNo(
                                        string.Format(Resources.SetNewCurrentTask, task.GetTaskNumber()));
            if (dialogResult != DialogResult.Yes) return;
            setAsCurrentTaskId(task.Entity.Id, true);
        }

        public static void RemoveCurrentTask(string taskNr)
        {
            var dialogResult = MessageBoxUtil.GetConfirmationYesNo(
                                        string.Format(Resources.RemoveCurrentTask, taskNr));
            if (dialogResult != DialogResult.Yes) return;
            removeCurrentTaskId(null, true);
        }

        private static void changeCurrentTask(Task task, string currentTask)
        {
            var dialogResult = MessageBoxUtil.ShowMessageBox(
                                string.Format(Resources.ChangeCurrentTask, currentTask, task.GetTaskNumber()),
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (dialogResult)
            {
                case DialogResult.Yes:
                    setAsCurrentTaskId(task.Entity.Id, true);
                    break;
                case DialogResult.No:
                    removeCurrentTaskId(null, true);
                    break;
            }
        }

        #endregion

        #region Clear current task

        public static void ClearCurrentTask(string notes = null)
        {
            var taskId = getCurrentTaskId();
            if (taskId == null)
                return;

            var repo = new TaskRepository();
            var taskExecutions = repo.GetTaskExecutionsById(getTaskExecutionId(taskId));

            if (taskExecutions == null)
                return;

            foreach (var execution in taskExecutions.Executions.Where(e => !e.StoppedAt.HasValue))
            {
                execution.StoppedAt = DateTime.Now;
                execution.Notes = notes;
            }

            repo.Save(taskExecutions);

            var userConfigs = UserConfig.GetConfigs(_userCurrentTaskKey, getCurrentTaskId());

            if (userConfigs == null)
                return;

            foreach (var config in userConfigs)
                UserConfig.SetConfig(config.UserId, _userCurrentTaskKey);
        }

        #endregion

        #region Common

        private static void setAsCurrentTaskId(string taskId, bool getReason = false)
        {
            removeCurrentTaskId(null, getReason);
            UserConfig.SetConfig(_userCurrentTaskKey, taskId);
            var repo = new TaskRepository();
            var taskExecutions = repo.GetTaskExecutionsById(getTaskExecutionId(taskId));
            taskExecutions = taskExecutions ?? new TaskExecutionEntity(getTaskExecutionId(taskId));
            taskExecutions.Executions.Add(ExecutionEntity.New());
            repo.Save(taskExecutions);
        }

        private static void removeCurrentTaskId(string notes = null, bool getReason = false)
        {
            //TODO: Refactor it
            var taskId = getCurrentTaskId();
            if (taskId == null)
                return;

            var repo = new TaskRepository();
            var taskExecutions = repo.GetTaskExecutionsById(getTaskExecutionId(taskId));

            if (taskExecutions == null)
                return;

            if (getReason)
            {
                notes = showNotesForm();
                if (notes == null)
                    throw new ValidationException(Resources.NoChangesMade);
            }

            var taskExecution = taskExecutions.Executions
                                    .SingleOrDefault(e => !e.StoppedAt.HasValue &&
                                            e.UserId == GravitySession.User.Entity.Id);

            if (taskExecution != null)
            {
                taskExecution.StoppedAt = DateTime.Now;
                taskExecution.Notes = notes;
            }

            repo.Save(taskExecutions);

            UserConfig.SetConfig(_userCurrentTaskKey, null);
        }

        private static string getTaskExecutionId(string taskId)
        {
            return string.Format("{0}/{1}", taskId, _taskExecutionsSuffixKey);
        }

        private static string showNotesForm()
        {
            var args = getTaskExecutionArgs();
            var notesForm = new FNotes(args);
            var result = notesForm.ShowDialog();
            return result != DialogResult.OK ? null : args.Notes;
        }

        private static NotesFormArgs getTaskExecutionArgs()
        {
            var args = new NotesFormArgs();
            args.Caption = "Reason for stoping current task";
            args.Title = "Current task stoping reason";
            args.Required = true;
            return args;
        }

        #endregion

        public static TaskExecutionEntity GetFaultyTaskExecution()
        {
            var currentTaskId = getCurrentTaskId();
            if (currentTaskId == null)
                return null;

            var repo = new TaskRepository();
            var taskExecutions = repo.GetTaskExecutionsById(getTaskExecutionId(currentTaskId));

            if (taskExecutions == null)
                return null;

            clearPreviousErrorExecutions(taskExecutions);
            var taskExecution = taskExecutions.Executions
                                    .SingleOrDefault(e => !e.StoppedAt.HasValue &&
                                            e.UserId == GravitySession.User.Entity.Id);
            return taskExecution == null ? null : taskExecutions;
        }

        private static void clearPreviousErrorExecutions(TaskExecutionEntity taskExecutions)
        {
            var execution = taskExecutions.Executions
                                .Where(e => !e.StoppedAt.HasValue && e.UserId == GravitySession.User.Entity.Id)
                                .OrderByDescending(e => e.StartedAt).ToList();
            if (execution.Count <= 1)
                return;

            for (var i = 1; i < execution.Count; i++)
            {
                execution[i].StoppedAt = DateTime.Now;
                execution[i].Notes = "System Recovered";
            }

            var repo = new TaskRepository();
            repo.Save(taskExecutions);
        }

        public static void ReassignCurrentTask()
        {
            var currentTaskId = getCurrentTaskId();
            if (currentTaskId == null)
                return;

            setAsCurrentTaskId(currentTaskId);
        }

        public static void HaltCurrentTask(string notes = null)
        {
            var currentTaskId = getCurrentTaskId();
            if (currentTaskId == null)
                return;

            var repo = new TaskRepository();
            var taskExecutions = repo.GetTaskExecutionsById(getTaskExecutionId(currentTaskId));

            if (taskExecutions == null)
                return;

            clearPreviousErrorExecutions(taskExecutions);
            var taskExecution = taskExecutions.Executions
                                    .SingleOrDefault(e => !e.StoppedAt.HasValue &&
                                            e.UserId == GravitySession.User.Entity.Id);

            if (taskExecution == null)
                return;

            taskExecution.StoppedAt = DateTime.Now;
            taskExecution.Notes = notes;

            repo.Save(taskExecutions);
        }

        public static CurrentTaskDetails GetCurrentTaskDetails()
        {
            var details = new CurrentTaskDetails();
            var ts = new TimeSpan();

            var currentTaskId = getCurrentTaskId();
            if (currentTaskId == null)
                return details;

            var repo = new TaskRepository();
            details.TaskNr = Task.GetTaskNumber(currentTaskId);

            var taskExecutions = repo.GetTaskExecutionsById(getTaskExecutionId(currentTaskId));

            if (taskExecutions == null)
                return details;

            clearPreviousErrorExecutions(taskExecutions);
            var taskExecution = taskExecutions.Executions
                                    .SingleOrDefault(e => !e.StoppedAt.HasValue &&
                                            e.UserId == GravitySession.User.Entity.Id);
            if (taskExecution == null)
                return details;

            details.StartTime = taskExecution.StartedAt;
            details.TotalDuration = taskExecutions.Executions
                                    .Where(e => e.StoppedAt.HasValue)
                                    .Aggregate(ts, (current, execution) =>
                                                execution.StoppedAt != null
                                                    ? current + (execution.StoppedAt.Value - execution.StartedAt).Duration()
                                                    : new TimeSpan());

            return details;
        }
    }
}
