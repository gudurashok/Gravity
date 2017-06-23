using System;
using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.Domain.ViewModel;
using Synergy.UC.Forms;

namespace Synergy.UC.Controls
{
    public partial class UReminderPopup : UPicklist
    {
        #region Declarations

        public event EventHandler Close;
        public event EventHandler StopSound;
        public event EventHandler Snooze;
        public event EventHandler ReminderItemOpened;

        internal int SnoozeMinutes;

        #endregion

        #region Constructor

        public UReminderPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialization

        public override void Initialize()
        {
            MakeList();
            SearchProperty = "Name";
            buildColumns();
            EnumUtil.LoadEnumListItems(cmbSnoozeDuration, typeof(Duration), Duration.FiveMins, 0);
            Repository = new TaskReminders();
            FillList();
            hookEventHandlers();
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("TaskNr", "Task Nr", 60));
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("DueIn", 150));
        }

        private void hookEventHandlers()
        {
            ListView.ItemSelectionChanged +=ListView_ItemSelectionChanged;
        }

        void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(setCommandButtonsState);
        }

        #endregion

        #region Open selected task

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            EventHandlerExecutor.Execute(openSelectedTask);
        }

        private void openSelectedTask()
        {
            var task = getSelectedReminderTask();
            if (task == null)
                return;

            OnReminderItemOpened(new EventArgs());
            var taskForm = new FTask(task);
            taskForm.ShowDialog();
        }

        private Task getSelectedReminderTask()
        {
            var reminder = getSelectedReminder();
            return string.IsNullOrWhiteSpace(reminder.Entity.TaskId)
                        ? null
                        : Task.GetFullDetailedTaskBy(reminder.Entity.TaskId);
        }

        #endregion

        #region Dismiss single reminder

        private void btnDismiss_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteSelectedMessage);
        }

        private void deleteSelectedMessage()
        {
            TaskReminder.DeleteReminderOfCurrentUser(getSelectedReminder());
            RefreshList();

            if (!ListView.HasItems())
                OnClose(new EventArgs());
        }

        #endregion

        #region Dismiss all reminders

        private void btnDismissAll_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteAllReminders);
        }

        private void deleteAllReminders()
        {
            TaskReminder.DeleteAllRemindersOfCurrentUser();
            OnClose(new EventArgs());
        }

        #endregion

        #region Common

        public void RefreshList()
        {
            FillList(true);
            setCommandButtonsState();
        }

        private TaskReminder getSelectedReminder()
        {
            return ((TaskReminderListItem)ListView.SelectedItems[0].Tag).Reminder;
        }

        private void setCommandButtonsState()
        {
            btnOpen.Enabled = ListView.HasAnyItemsSelected() && IsTask();
            btnDismiss.Enabled = ListView.HasAnyItemsSelected();
        }

        private bool IsTask()
        {
            var reminder = getSelectedReminder();
            return !string.IsNullOrWhiteSpace(reminder.Entity.TaskId);
        }

        protected virtual void OnClose(EventArgs e)
        {
            if (Close != null)
                Close(this, e);
        }

        #endregion

        #region Snooze

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            SnoozeMinutes = (int)(Duration)cmbSnoozeDuration.SelectedValue;
            OnSnooze(EventArgs.Empty);
        }

        protected virtual void OnSnooze(EventArgs e)
        {
            if (Snooze != null)
                Snooze(this, e);
        }

        private void cmbSnoozeDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSnoozeDuration.SelectedIndex == -1 && cmbSnoozeDuration.Items.Count > 0)
                cmbSnoozeDuration.SelectedIndex = 0;
        }

        #endregion

        private void btnStopSound_Click(object sender, EventArgs e)
        {
            OnStopSound(e);
        }

        protected virtual void OnStopSound(EventArgs e)
        {
            if (StopSound != null)
                StopSound(this, e);
        }

        public void OnReminderItemOpened(EventArgs e)
        {
            if (ReminderItemOpened != null)
                ReminderItemOpened(this, e);
        }
    }
}
