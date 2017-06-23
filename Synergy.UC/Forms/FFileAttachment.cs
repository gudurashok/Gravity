using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Win.Forms;
using Synergy.Domain.Entities;
using Synergy.Domain.Model;

namespace Synergy.UC.Forms
{
    public partial class FFileAttachment : FFormBase
    {
        private readonly Task _task;

        public FFileAttachment(Task task)
        {
            InitializeComponent();
            _task = task;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            EventHandlerExecutor.Execute(initialize);
        }

        private void initialize()
        {
            setFormTitle();
            uFileAttachment.ReadOnly = !_task.CanEdit(GravitySession.User);
            uFileAttachment.DataSource = _task.Entity.Attachments;
            uFileAttachment.Initialize();
            uFileAttachment.MakeList();
        }

        private void setFormTitle()
        {
            Text = getFormTitle();
            lblTitle.Text = getTitleText();
        }

        private string getFormTitle()
        {
            return _task.IsNew() ? "New Task" : string.Format("Task: #{0} ", _task.GetTaskNumber());
        }

        private string getTitleText()
        {
            return string.Format("Add attachments for {0}", _task.IsNew() ? "new task" : _task.Entity.Name);
        }

        private void uFileAttachment_AttachmentsSaved(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAttachmentSaved);
        }

        private void processAttachmentSaved()
        {
            _task.Entity.Attachments = uFileAttachment.DataSource as IList<AttachmentEntity>;
            DialogResult = DialogResult.OK;
        }
    }
}
