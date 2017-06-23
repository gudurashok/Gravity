using Synergy.Domain.Indexes;
using Synergy.Domain.Model;

namespace Synergy.Domain.ViewModel
{
    public class TaskStatsListItem
    {
        public TaskStats TaskStats { get; set; }
        public Task CurrentTask { get; set; }

        public string UserName
        {
            get { return TaskStats.UserName; }
        }

        public string Total
        {
            get { return TaskStats.Total.ToString(); }
        }

        public string Pending
        {
            get { return TaskStats.Pending.ToString(); }
        }

        public string Cancelled
        {
            get { return TaskStats.Cancelled.ToString(); }
        }

        public string Completed
        {
            get { return TaskStats.Completed.ToString(); }
        }

        public string OverDue
        {
            get { return TaskStats.OverDue.ToString(); }
        }

        public string NotStarted
        {
            get { return TaskStats.NotStarted.ToString(); }
        }

        public string StartedToday
        {
            get { return TaskStats.StartedToday.ToString(); }
        }

        public string DueToday
        {
            get { return TaskStats.DueToday.ToString(); }
        }

        public string DueThisWeek
        {
            get { return TaskStats.DueThisWeek.ToString(); }
        }

        public string CurrentTaskNr
        {
            get
            {
                return CurrentTask == null ? string.Empty : string.Format("Task #{0}", CurrentTask.GetTaskNumber());
            }
        }
    }
}
