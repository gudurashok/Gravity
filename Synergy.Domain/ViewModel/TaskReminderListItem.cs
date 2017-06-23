using System;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;

namespace Synergy.Domain.ViewModel
{
    public class TaskReminderListItem
    {
        public TaskReminder Reminder { get; set; }

        public string TaskNr
        {
            get
            {
                return string.IsNullOrWhiteSpace(Reminder.Entity.TaskId)
                            ? string.Empty
                            : Task.GetTaskNumber(Reminder.Entity.TaskId).PadLeft(12);
            }
        }

        public string Name
        {
            get { return Reminder.Entity.Name; }
        }

        public string RemindOn
        {
            get { return Reminder.Entity.RemindOn.ToString("dd/MM/yyyy  hh:mm tt"); }
        }

        public string DueIn
        {
            get { return getDueIn(); }
        }

        private string getDueIn()
        {
            var dueOn = Reminder.Entity.RemindOn;

            if (!string.IsNullOrWhiteSpace(Reminder.Entity.TaskId))
            {
                var repo = new TaskRepository();
                var task = repo.GetTaskEntityBy(Reminder.Entity.TaskId);

                if (task != null)
                {
                    if (task.DueDate.HasValue)
                        dueOn = task.DueDate.Value;

                    if (task.StartDate.HasValue && !task.DueDate.HasValue)
                        return string.Format("Started {0} ago", getDuration(task.StartDate.Value));
                }
            }

            if ((int)(DateTime.Now - dueOn).TotalMinutes == 0)
                return string.Format("Time completed");

            if (dueOn > DateTime.Now)
                return string.Format("Due in {0}", getDuration(dueOn));

            if (dueOn < DateTime.Now)
                return string.Format("Overdue {0}", getDuration(dueOn));

            return "";
        }

        private string getDuration(DateTime dueOn)
        {
            var ts = dueOn == DateTime.MinValue
                        ? (DateTime.Now - Reminder.Entity.RemindOn).Duration()
                        : (DateTime.Now - dueOn).Duration();
            return string.Format("{0}d: {1}h: {2}m", ts.Days, ts.Hours, ts.Minutes);
        }
    }
}
