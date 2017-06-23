using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scalable.Win.FormControls;
using Scalable.Shared.Common;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Gravity.Root.Enums;

namespace Gravity.Root.Controls
{
    public partial class UUserFeedback : UFormBase
    {
        public event EventHandler CloseForm;

        public UUserFeedback()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            initialize();
            base.OnLoad(e);
        }

        private void initialize()
        {
            EnumUtil.LoadEnumListItems(cmbFeedbackType, typeof(FeedbackType));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSendMail);
        }

        private void processSendMail()
        {
            if (string.IsNullOrWhiteSpace(txtFeedback.Text))
                throw new ValidationException("Enter Feedback Message");

            Emailer.SendMail(createMessage());
            MessageBoxUtil.ShowMessage("Your feedback has been sent successfully to Synergy team");
            OnCloseForm(EventArgs.Empty);
        }

        protected virtual void OnCloseForm(EventArgs e)
        {
            if (CloseForm != null)
                CloseForm(this, e);
        }

        private EmailMessage createMessage()
        {
            return new EmailMessage
            {
                FromAddress = "synergy.userfeedback@gmail.com",
                FromAddressDisplayName = "Synergy User Feedback",
                FromPassword = StringCipher.Decrypt("zNElhP2H2K9AVdqSolXa5g==", "SynergyUserFeedbackMailPassword"),
                ToAddress = "synergy.userfeedback@gmail.com",
                ToAddressDisplayName = "Synergy",
                Subject = getSubject(),
                Body = txtFeedback.Text
            };
        }

        private string getSubject()
        {
            return string.Format("Synergy User Feedback From: {0} By User: {1}",
                                        GravitySession.CompanyGroup.Entity.Name,
                                        GravitySession.User.Entity.Name);
        }
    }
}
