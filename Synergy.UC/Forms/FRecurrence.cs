using System;
using System.Windows.Forms;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Win.Forms;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FRecurrence : FFormBase
    {
        private readonly Task _task;

        public FRecurrence()
        {
            InitializeComponent();
        }

        public FRecurrence(Task task)
            : this()
        {
            _task = task;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EventHandlerExecutor.Execute(initialize);
        }

        private void initialize()
        {
            uRecurrence.Enabled = _task.CanEdit(GravitySession.User);
            setFormTitle();
            uRecurrence.RecurrenceSaved += uRecurrence_RecurrenceSaved;
            uRecurrence.RecurrenceRemoved += uRecurrence_RecurrenceRemoved;
            uRecurrence.Initialize(_task.Entity.Recurrence);
        }

        void uRecurrence_RecurrenceRemoved(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processRemoveRecurrence);
        }

        void processRemoveRecurrence()
        {
            _task.Entity.Recurrence = null;
            DialogResult = DialogResult.OK;
        }

        void uRecurrence_RecurrenceSaved(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSaveRecurrence);
        }

        void processSaveRecurrence()
        {
            _task.Entity.Recurrence = uRecurrence.Recurrence;
            DialogResult = DialogResult.OK;
        }

        private void setFormTitle()
        {
            Text = string.Format("Task: {0}", getFormTitle());
            lblTitle.Text = getTitleText();
        }

        private string getFormTitle()
        {
            return _task.IsNew() ? "New Task" : string.Format("#{0} ", _task.GetTaskNumber());
        }

        private string getTitleText()
        {
            return _task.IsNew() ? "Enter new task recurrence details" : _task.Entity.Name;
        }
    }
}
