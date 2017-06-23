using System;
using Scalable.Win.Forms;
using Synergy.Domain.Model;

namespace Synergy.Win.Forms
{
    public partial class FTaskType : FFormBase
    {
        private readonly Task _task;

        public FTaskType(Task task)
        {
            InitializeComponent();
            _task = task;
        }

        protected override void OnLoad(EventArgs e)
        {
            uTaskType.Initialize();
            uTaskType.DataSource = _task;
            setFormTitle();
        }

        private void setFormTitle()
        {
            Text = string.Format("Task: {0}", getFormTitle());
            lblTitle.Text = getTitleText();
        }

        private string getFormTitle()
        {
            return _task.IsNew() ? "New Task" : _task.Entity.Name;
        }

        private string getTitleText()
        {
            return _task.IsNew() ? "Set new task details" : _task.Entity.Name;
        }

    }
}
