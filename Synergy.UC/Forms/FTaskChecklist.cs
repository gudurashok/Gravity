using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gravity.Root.Common;
using Scalable.Win.Forms;
using Synergy.Domain.Entities;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FTaskChecklist : FFormBase
    {
        private readonly Task _task;

        public FTaskChecklist(Task task)
        {
            _task = task;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            setFormTitle();
            uTaskChecklist.DataSource = _task.Entity.Checklist.Items;
            uTaskChecklist.Initialize();
            uTaskChecklist.Readonly = !_task.CanComplete(GravitySession.User);
            uTaskChecklist.SaveChecklist += uTaskChecklist_SaveChecklist;
        }

        private void setFormTitle()
        {
            Text = string.Format("Task: {0}", getFormTitle());
            lblTitle.Text = getTitleText();
        }

        private string getFormTitle()
        {
            return string.Format("Checklist for Task #{0}", _task.GetTaskNumber());
        }

        private string getTitleText()
        {
            return string.Format("Select Checklist Items for \"{0}\"", _task.Entity.Name);
        }

        void uTaskChecklist_SaveChecklist(object sender, EventArgs e)
        {
            if (!uTaskChecklist.Readonly)
            {
                _task.Entity.Checklist.Items = uTaskChecklist.DataSource as IList<ChecklistItemEntity>;
                _task.Save(true);
                TaskMessage.SendTaskChecklistUpdatedMessage(_task);
            }
            DialogResult = DialogResult.OK;
        }
    }
}
