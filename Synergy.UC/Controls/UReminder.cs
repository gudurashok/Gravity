using System;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;
using Synergy.Domain.Model;
using Synergy.Domain.ViewModel;
using Synergy.UC.Picklists;

namespace Synergy.UC.Controls
{
    public partial class UReminder : UBaseForm
    {
        private TaskReminder _reminder;
        public event EventHandler<EventArgs> ReminderSaved;
        public event EventHandler<EventArgs> Cancelled;

        public UReminder()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            txbTask.PickList = PicklistFactory.Tasks.Form;
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _reminder;
            }
            set
            {
                _reminder = value as TaskReminder;
                fillForm();
            }
        }

        private void fillObject()
        {
            if (_reminder.Entity.UserIds.Count == 0 || 
                    !_reminder.Entity.UserIds.Contains(GravitySession.User.Entity.Id))
                _reminder.Entity.UserIds.Add(GravitySession.User.Entity.Id);

            fillTaskDetails();
            _reminder.Entity.Name = txtName.Text;
            _reminder.Entity.RemindOn = getReminderDateTime();
        }

        private DateTime getReminderDateTime()
        {
            return new DateTime(
                        dtpReminderDate.Value.Year,
                        dtpReminderDate.Value.Month,
                        dtpReminderDate.Value.Day,
                        dtpReminderTime.Value.Hour,
                        dtpReminderTime.Value.Minute, 0);
        }

        private void fillTaskDetails()
        {
            if (txbTask.Value == null)
                return;

            var task = ((TaskListItem)txbTask.Value).Task;
            _reminder.Entity.TaskId = task.Entity.Id;
            //_reminder.Entity.TaskNr = task.Entity.Number;
        }

        private void fillForm()
        {
            txbTask.Value = getTask();
            txtName.Text = _reminder.Entity.Name;
            dtpReminderDate.Value = _reminder.Entity.RemindOn == DateTime.MinValue
                                        ? DateTime.Now : _reminder.Entity.RemindOn;
            dtpReminderTime.Value = dtpReminderDate.Value;
        }

        private TaskListItem getTask()
        {
            return _reminder.Entity.TaskId == null
                        ? null
                        : new TaskListItem { Task = Task.GetFullDetailedTaskBy(_reminder.Entity.TaskId) };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveReminder);
        }

        private void saveReminder()
        {
            ((TaskReminder)DataSource).Save();
            OnReminderSaved(new EventArgs());
        }

        protected virtual void OnReminderSaved(EventArgs e)
        {
            if (ReminderSaved != null)
                ReminderSaved(this, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnCancelled(EventArgs.Empty);
        }

        protected virtual void OnCancelled(EventArgs e)
        {
            if (Cancelled != null)
                Cancelled(this, e);
        }

        private void txbTask_Leave(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processLeave);
        }

        void processLeave()
        {
            if (txbTask.Value == null)
            {
                txtName.Enabled = true;
                txtName.Focus();
                return;
            }

            var task = ((TaskListItem)txbTask.Value).Task;
            txtName.Text = string.Format(task.Entity.Name);
            txtName.Enabled = false;
            dtpReminderDate.Focus();
        }
    }
}
