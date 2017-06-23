using System;
using System.Threading;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.Domain.ViewModel;
using Synergy.UC.Forms;

namespace Synergy.UC.Controls
{
    public partial class UReminders : UListView
    {
        #region Constructor

        public UReminders()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialization

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new TaskReminders(true);
            FillList();
            uReminder.Initialize();
            uReminder.ReminderSaved += uReminder_ReminderSaved;
            uReminder.Cancelled += uReminder_Cancelled;
        }

        void uReminder_Cancelled(object sender, EventArgs e)
        {
            RefreshForm();
            uReminder.Enabled = false;
            uReminder.DataSource = getSelectedReminder();
        }

        void uReminder_ReminderSaved(object sender, EventArgs e)
        {
            RefreshForm();
            uReminder.Enabled = false;
            uReminder.DataSource = getSelectedReminder();
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("TaskNr", "Task Nr", 60));
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("RemindOn", "Remind on", 150));
        }

        #endregion

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            setButtonsState();
            if (uReminder.Enabled)
                return;

            uReminder.DataSource = getSelectedReminder();
        }

        private TaskReminder getSelectedReminder()
        {
            return ListView.HasAnyItemsSelected()
                       ? ((TaskReminderListItem)ListView.SelectedItems[0].Tag).Reminder
                       : TaskReminder.New();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewReminder);
        }

        void processNewReminder()
        {
            RefreshForm();
            uReminder.Enabled = true;
            uReminder.DataSource = TaskReminder.New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditReminder);
        }

        void processEditReminder()
        {
            RefreshForm();
            uReminder.Enabled = true;
            uReminder.DataSource = getSelectedReminder();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDelete);
        }

        void processDelete()
        {
            TaskReminder.DeleteReminderOfCurrentUser(getSelectedReminder());
            RefreshForm();
            uReminder.Enabled = false;
            uReminder.DataSource = getSelectedReminder();
        }

        private void setButtonsState()
        {
            btnEdit.Enabled = ListView.HasAnyItemsSelected() && IsNotDefault();
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
            btnOpen.Enabled = ListView.HasAnyItemsSelected() && IsTask();
        }

        private bool IsTask()
        {
            var reminder = getSelectedReminder();
            return !string.IsNullOrWhiteSpace(reminder.Entity.TaskId);
        }

        private bool IsNotDefault()
        {
            return !getSelectedReminder().Entity.IsDefault;
        }

        public void RefreshForm()
        {
            FillList(true);
            setButtonsState();
        }

        private void lvw_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processItemSelected);
        }

        void processItemSelected()
        {
            var reminder = getSelectedReminder();
            if (string.IsNullOrWhiteSpace(reminder.Entity.TaskId))
                return;

            var repo = new TaskRepository();
            var task = repo.GetTaskEntityBy(reminder.Entity.TaskId);

            var taskForm = new FTask(new Task(task));
            taskForm.ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processItemSelected);
        }
    }
}