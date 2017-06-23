using System;
using System.Text;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;

namespace Synergy.Domain.ViewModel
{
    public class TaskListItem
    {
        public Task Task { get; set; }

        public string Nr
        {
            get { return Task.GetTaskNumber().PadLeft(12); }
        }

        public string Name
        {
            get { return Task.Entity.Name; }
        }

        public string Tag
        {
            get { return Task.Entity.Tag; }
        }

        public string ParentTaskNr
        {
            get { return Task.Parent == null ? "" : Task.Parent.GetTaskNumber().PadLeft(12); }
        }

        public Priority Priority
        {
            get { return Task.Entity.Priority; }
        }

        public string Attachments
        {
            get
            {
                if (Task.Entity.Attachments == null || Task.Entity.Attachments.Count == 0)
                    return string.Empty;

                return Task.Entity.Attachments.Count.ToString();
            }
        }

        public string Comments
        {
            get
            {
                var repo = new TaskRepository();
                var count = repo.TaskCommentsCount(Task.Entity.Id);
                return count == 0 ? string.Empty : count.ToString();
            }
        }

        public string Status
        {
            get { return getStatus(); }
        }

        private string getStatus()
        {
            var result = new StringBuilder();
            result.Append(Task.Entity.Status == TaskStatus.Pending ? getPendingStatus() : getCompletedStatus());

            if (Task.Entity.StartDate.HasValue && Task.Entity.StartDate.Value > DateTime.Now)
                return result.ToString();

            result.Append(string.Format(" {0}% done", Task.Entity.CompletePct));
            return result.ToString();
        }

        private string getPendingStatus()
        {
            if (Task.Entity.StartDate == null && Task.Entity.DueDate == null)
            {
                var ts = DateTime.Now.Subtract(Task.Entity.CreatedOn);
                return string.Format("{0}d {1}h {2}m old", ts.Days, ts.Hours, ts.Minutes);
            }

            var result = new StringBuilder();
            if (Task.Entity.DueDate.HasValue)
            {
                TimeSpan ts;
                if (Task.Entity.DueDate.Value.TimeOfDay == DateTime.MinValue.TimeOfDay)
                {
                    ts = DateTime.Today.Subtract(Task.Entity.DueDate.Value.Date).Duration();
                    result.Append(Task.Entity.DueDate.Value.Date < DateTime.Today
                                      ? string.Format("Over due {0} day(s)", ts.Days + 1)
                                      : string.Format("Due in {0} day(s)", ts.Days + 1));
                }
                else
                {
                    ts = DateTime.Now.Subtract(Task.Entity.DueDate.Value).Duration();
                    result.Append(Task.Entity.DueDate.Value < DateTime.Now
                                      ? string.Format("Over due {0}d {1}h {2}m", ts.Days, ts.Hours, ts.Minutes)
                                      : string.Format("Due in {0}d {1}h {2}m", ts.Days, ts.Hours, ts.Minutes));
                }
            }

            if (result.Length > 0) result.Append(" ; ");

            if (Task.Entity.StartDate.HasValue)
            {
                TimeSpan ts;
                if (Task.Entity.StartDate.Value.TimeOfDay == DateTime.MinValue.TimeOfDay)
                {

                    ts = DateTime.Today.Subtract(Task.Entity.StartDate.Value.Date).Duration();
                    result.Append(Task.Entity.StartDate.Value.Date < DateTime.Today
                            ? string.Format("Started {0} day(s) ago", ts.Days)
                            : string.Format("{0} day(s) to start", ts.Days));
                }
                else
                {
                    ts = DateTime.Now.Subtract(Task.Entity.StartDate.Value).Duration();
                    result.Append(Task.Entity.StartDate.Value < DateTime.Now
                            ? string.Format("Started {0}d {1}h {2}m ago", ts.Days, ts.Hours, ts.Minutes)
                            : string.Format("{0}d {1}h {2}m to start", ts.Days, ts.Hours, ts.Minutes));
                }
            }

            return result.ToString();
        }

        private string getCompletedStatus()
        {
            if (Task.Entity.CompletedOn.HasValue)
            {
                var ts = DateTime.Now.Subtract(Task.Entity.CompletedOn.Value);
                return string.Format("{0} {1}d {2}h {3}m ago", Task.Entity.Status, ts.Days, ts.Hours, ts.Minutes);
            }

            return string.Empty;
        }
    }
}
