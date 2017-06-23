using System;
using System.Windows.Forms;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Win.Forms;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FTaskAdvanced : FFormBase
    {
        private readonly Task _task;

        #region Constructor

        public FTaskAdvanced(Task task)
        {
            InitializeComponent();
            _task = task;
        }

        #endregion

        #region Load

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EventHandlerExecutor.Execute(intialize);
        }

        #endregion

        void intialize()
        {
            uTaskAdvanced.Enabled = _task.CanEdit(GravitySession.User);
            setFormTitle();
            uTaskAdvanced.Initialize();
            uTaskAdvanced.DataSource = _task;
            uTaskAdvanced.TaskSaved += uTaskAdvanced_TaskSaved;
        }

        void uTaskAdvanced_TaskSaved(object sender, EventArgs e)
        {
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
            return _task.IsNew() ? "Enter new task details" : _task.Entity.Name;
        }
    }
}
