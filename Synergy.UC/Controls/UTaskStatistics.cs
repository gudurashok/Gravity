using System;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Synergy.Domain.Repositories;
using Synergy.Domain.ViewModel;

namespace Synergy.UC.Controls
{
    public partial class UTaskStatistics : UListView
    {
        public UTaskStatistics()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            SearchProperty = "UserName";
            buildColumns();
            Repository = new TaskStatistics();
            FillList(true);
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("UserName", "User Name", true));
            ListView.Columns.Add(new iColumnHeader("Total", 50));
            ListView.Columns.Add(new iColumnHeader("Pending", 60));
            ListView.Columns.Add(new iColumnHeader("Cancelled", 70));
            ListView.Columns.Add(new iColumnHeader("Completed", 70));
            ListView.Columns.Add(new iColumnHeader("OverDue", 60));
            ListView.Columns.Add(new iColumnHeader("NotStarted", "Not started", 70));
            ListView.Columns.Add(new iColumnHeader("StartedToday", "Started today", 80));
            ListView.Columns.Add(new iColumnHeader("DueToday", "Due today", 70));
            ListView.Columns.Add(new iColumnHeader("DueThisWeek", "Due this week", 90));
            ListView.Columns.Add(new iColumnHeader("CurrentTaskNr", "Current Task", 80)); //Task Nr
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(displayCurrentTaskName);
        }

        void displayCurrentTaskName()
        {
            if (lvw.SelectedItems.Count == 0)
            {
                txtCurrentTask.Text = string.Empty;
                return;
            }

            var taskStat = (TaskStatsListItem)lvw.SelectedItems[0].Tag;
            txtCurrentTask.Text = taskStat.CurrentTask == null
                                    ? string.Empty
                                    : string.Format("Task #{0}: {1}",
                                                    taskStat.CurrentTask.GetTaskNumber(),
                                                    taskStat.CurrentTask.Entity.Name);
        }
    }
}
