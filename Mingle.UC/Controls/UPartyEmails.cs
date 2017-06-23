using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.UC.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyEmails : UBaseForm
    {
        private IList<Email> _emails;

        public UPartyEmails()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            buildColumns();
            fillDropDowns();
        }

        private void fillDropDowns()
        {
            var oldValue = cmbTitle.Text;
            cmbTitle.DataSource = null;
            cmbTitle.DataSource = ReferenceList.GetList(ListType.EmailTypes);
            cmbTitle.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Label", "Title", 100));
            ListView.Columns.Add(new iColumnHeader("EmailId", "Email Id", true));
        }

        public override object DataSource
        {
            get
            {
                return _emails;
            }
            set
            {
                _emails = (value as IList<Email>).Select(e => e).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            fillList();
            processItemSelection();
        }

        private void fillList()
        {
            ListView.FillData(_emails.OrderByDescending(e => e.IsPreferred));
            ListView.BoldListItem(ListView.Items.Cast<ListViewItem>().SingleOrDefault(i => ((Email) i.Tag).IsPreferred));
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processItemSelection);
        }

        void processItemSelection()
        {
            setCommandButtonStates();
            fillControls();
        }

        private void fillControls()
        {
            var email = ListView.HasAnyItemsSelected() ? getSelectedEmail() : new Email();
            cmbTitle.Text = email.Label;
            txtEmail.Text = email.EmailId;
            chkIsActive.Checked = email.IsActive;
        }

        private void setCommandButtonStates()
        {
            btnUpdate.Enabled = ListView.HasAnyItemsSelected();
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
            btnPreferred.Enabled = ListView.HasAnyItemsSelected();
            chkIsActive.Enabled = ListView.HasAnyItemsSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(addEmail);
        }

        void addEmail()
        {
            var email = new Email();
            fillEmail(email);
            validate(email);
            _emails.Add(email);
            fillList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateEmail);
        }

        private void updateEmail()
        {
            var email = getSelectedEmail();
            fillEmail(email);
            validate(email);
            fillList();
        }

        private void validate(Email email)
        {
            email.Validate();
            var selectedEmail = _emails.Where(e => e != email)
                                    .SingleOrDefault(e => e.Label == cmbTitle.Text.Trim() &&
                                                        e.ToString() == txtEmail.Text.Trim());
            if (selectedEmail != null)
                throw new ValidationException(Resources.EmailWithSameTitleAlreadyExist);
        }

        private void fillEmail(Email email)
        {
            email.Label = cmbTitle.Text.Trim();
            email.EmailId = txtEmail.Text.Trim();
            email.IsActive = true;
        }

        private Email getSelectedEmail()
        {
            return ListView.SelectedItems.Count > 0
                        ? (Email)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteEmail);
        }

        private void deleteEmail()
        {
            var email = getSelectedEmail();
            _emails.Remove(email);
            fillList();
            processItemSelection();
        }

        private void btnPreferred_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setPreferred);
        }

        void setPreferred()
        {
            foreach (var email in _emails)
                email.IsPreferred = false;

            var selectedEmail = getSelectedEmail();
            selectedEmail.IsPreferred = true;
            fillList();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setIsActiveFlag);
        }

        void setIsActiveFlag()
        {
            var email = getSelectedEmail();
            if (email != null)
                email.IsActive = chkIsActive.Checked;
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
