using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.UC.Common;

namespace Synergy.UC.Controls
{
    public partial class USmsPad : UFormBase
    {
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Task SelectedTask { get; set; }

        public event EventHandler CloseForm;

        private IList<string> _recipients;
        private RecipientType _recipientType;
        private IList<User> _users;
        private bool _cancelExit;

        public USmsPad()
        {
            InitializeComponent();
        }

        private void initialize()
        {
            lblCount.AutoSizeLeft = true;
            _users = new List<User>();
            EnumUtil.LoadEnumListItems(cmbRecipientType, typeof(RecipientType));
        }

        protected override void OnLoad(EventArgs e)
        {
            initialize();
            btnFillSelectedTask.Visible = SelectedTask != null;

            if (SelectedTask == null)
                contextMenuStrip.Dispose();

            if (!GravitySession.User.Entity.IsAdmin && !GravitySession.User.Entity.AllowAdHocNrs)
            {
                cmbRecipientType.SelectedIndex = 1;
                cmbRecipientType.Enabled = false;
            }

            base.OnLoad(e);
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            lblCount.Text = string.Format("Count: {0}", txtMessage.TextLength);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSendMessages);
        }

        void processSendMessages()
        {
            _recipients = new List<string>();

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                throw new ValidationException("Enter message");

            if (string.IsNullOrWhiteSpace(txtNumbers.Text))
                throw new ValidationException("Enter recipient number(s)");

            if (_recipientType == RecipientType.Numbers)
                _recipients = PhoneNumbersExtractor.GetNumbers(txtNumbers.Text);
            else
            {
                foreach (var mobileNrs in _users.Select(u => u.Entity.MobileNrs))
                    _recipients = _recipients.Union(PhoneNumbersExtractor.GetNumbers(mobileNrs)).ToList();
            }

            if (txtMessage.TextLength > 160)
            {
                var dialog = MessageBoxUtil.GetConfirmationYesNo(
                    "Message is exceeding 160 characters\nDo you want to send as multiple messages");
                if (dialog != DialogResult.Yes)
                {
                    _cancelExit = true;
                    return;
                }
            }

            new SmsServer().Send(_recipients, txtMessage.Text);
            MessageBoxUtil.ShowMessage("Your message has been queued!");
        }

        private void cmbRecipientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRecipientType.SelectedIndex == -1 && cmbRecipientType.Items.Count > 0)
            {
                cmbRecipientType.SelectedIndex = 0;
                return;
            }

            _recipientType = (RecipientType)cmbRecipientType.SelectedValue;

            if (_recipientType == RecipientType.Numbers)
            {
                txtNumbers.ReadOnly = false;
                txtNumbers.TabStop = true;
                btnUsers.Enabled = false;
                txtNumbers.Text = getRecipientNumbers();
            }
            else
            {
                txtNumbers.ReadOnly = true;
                txtNumbers.TabStop = false;
                btnUsers.Enabled = true;
                txtNumbers.Text = getUserNames();
            }
        }

        private string getRecipientNumbers()
        {
            return txtNumbers.Tag == null ? string.Empty : txtNumbers.Tag.ToString();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(showUsersList);
        }

        void showUsersList()
        {
            var fUsers = new FMultiUsers(_users);
            if (fUsers.ShowDialog() != DialogResult.OK)
                return;

            _users = fUsers.Users;
            txtNumbers.Text = getUserNames();
        }

        private string getUserNames()
        {
            if (_users == null)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var user in _users)
                sb.Append(user.Entity.Name).Append(", ");

            if (sb.Length >= 2)
                sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        private void txtNumbers_Leave(object sender, EventArgs e)
        {
            if (txtNumbers.ReadOnly)
                return;

            txtNumbers.Tag = txtNumbers.Text;
        }

        private void btnFillSelectedTask_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processFillTask);
        }

        private void processFillTask()
        {
            appendTaskDetails();
            addRecipient();
        }

        private void appendTaskDetails()
        {
            appendTaskName();
            //appendTaskDescription();
        }

        private void addRecipient()
        {
            var user = SelectedTask.AssignedTo ?? SelectedTask.CreatedBy;

            if (!_users.Contains(user))
                _users.Add(user);

            if (_recipientType == RecipientType.Numbers)
            {
                cmbRecipientType.SelectedIndex = 1;
                return;
            }

            txtNumbers.Text = getUserNames();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(appendTaskName);
        }

        void appendTaskName()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                sb.Append(SelectedTask.Entity.Name);
            else
                sb.Append(txtMessage.Text).AppendLine().Append(SelectedTask.Entity.Name);

            txtMessage.Text = sb.ToString();
        }

        private void descriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(appendTaskDescription);
        }

        void appendTaskDescription()
        {
            var sb = new StringBuilder();

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                sb.Append(SelectedTask.Entity.DescriptionText);
            else
                sb.Append(txtMessage.Text).AppendLine().Append(SelectedTask.Entity.DescriptionText);

            txtMessage.Text = sb.ToString();
        }

        private void btnSendAndExit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSendAndExit);
        }

        void processSendAndExit()
        {
            processSendMessages();
            if (_cancelExit)
                return;

            OnCloseForm(EventArgs.Empty);
        }

        protected virtual void OnCloseForm(EventArgs e)
        {
            if (CloseForm != null)
                CloseForm(this, e);
        }
    }
}
