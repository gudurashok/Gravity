using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.Domain.ViewModel;
using Mingle.UC.Picklists;
using Mingle.UC.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyContacts : UBaseForm
    {
        private IList<PartyContact> _contacts;

        public UPartyContacts()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            buildColumns();
            txbContacts.PickList = PicklistFactory.Parties.Form;
            fillDropDowns();
        }

        private void fillDropDowns()
        {
            fillDesignations();
            fillDepartments();
        }

        private void fillDesignations()
        {
            var oldValue = cmbDesignation.Text;
            cmbDesignation.DataSource = null;
            cmbDesignation.DataSource = ReferenceList.GetList(ListType.Designations);
            cmbDesignation.Text = oldValue;
        }

        private void fillDepartments()
        {
            var oldValue = cmbDepartment.Text;
            cmbDepartment.DataSource = null;
            cmbDepartment.DataSource = ReferenceList.GetList(ListType.Departments);
            cmbDepartment.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", "Contact", true));
            ListView.Columns.Add(new iColumnHeader("Designation", 120));
            ListView.Columns.Add(new iColumnHeader("Department", 120));
        }

        public override object DataSource
        {
            get
            {
                return _contacts;
            }
            set
            {
                _contacts = (value as IList<PartyContact>).Select(c => c).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            fillList();
            processSelectedContact();
        }

        private void fillList()
        {
            ListView.FillData(_contacts.OrderByDescending(c => c.IsPreferred));
            ListView.BoldListItem(ListView.Items.Cast<ListViewItem>().SingleOrDefault(i => ((PartyContact)i.Tag).IsPreferred));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(addContact);
        }

        void addContact()
        {
            var contact = new PartyContact();
            fillContact(contact);
            contact.Validate();
            validate(contact);
            _contacts.Add(contact);
            fillList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateContact);
        }

        void updateContact()
        {
            var contact = getSelectedContact();
            validate(contact);
            fillContact(contact);
            contact.Validate();
            fillList();
        }

        private void fillContact(PartyContact contact)
        {
            setContact(contact);
            contact.Designation = cmbDesignation.Text.Trim();
            contact.Department = cmbDepartment.Text.Trim();
            contact.IsActive = true;
        }

        private void setContact(PartyContact contact)
        {
            contact.Party = txbContacts.Value == null ? null : ((PartyListItem)txbContacts.Value).Party;
        }

        private PartyContact getSelectedContact()
        {
            return ListView.SelectedItems.Count > 0
                        ? (PartyContact)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteContact);
        }

        void deleteContact()
        {
            _contacts.Remove(getSelectedContact());
            fillList();
            processSelectedContact();
        }

        private void btnPreferred_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setAddressPreferred);
        }

        void setAddressPreferred()
        {
            foreach (var contact in _contacts)
                contact.IsPreferred = false;

            var selectedContact = getSelectedContact();
            selectedContact.IsPreferred = true;
            fillList();
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedContact);
        }

        void processSelectedContact()
        {
            setCommandButtonStates();
            fillControls();
        }

        private void setCommandButtonStates()
        {
            btnUpdate.Enabled = ListView.HasAnyItemsSelected();
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
            btnPreferred.Enabled = ListView.HasAnyItemsSelected();
            chkIsActive.Enabled = ListView.HasAnyItemsSelected();
        }

        private void fillControls()
        {
            var contact = ListView.HasAnyItemsSelected() ? getSelectedContact() : new PartyContact();
            txbContacts.Value = getContact(contact);
            cmbDesignation.Text = contact.Designation;
            cmbDepartment.Text = contact.Department;
            chkIsActive.Checked = contact.IsActive;
        }

        private PartyListItem getContact(PartyContact contact)
        {
            return contact.Party == null ? null : new PartyListItem { Party = contact.Party };
        }

        private void validate(PartyContact contact)
        {
            var selectedContact = _contacts.Where(c => c != contact)
                                    .SingleOrDefault(c => c.PartyId == getPartyId() &&
                                                        c.Designation == cmbDesignation.Text.Trim() &&
                                                        c.Department == cmbDepartment.Text.Trim());

            if (selectedContact != null)
                throw new ValidationException(Resources.ContactAlreadyExistWithSameDetails);
        }

        private string getPartyId()
        {
            return txbContacts.Value == null ? string.Empty : ((PartyListItem)txbContacts.Value).Party.Entity.Id;
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setIsActiveFlag);
        }

        void setIsActiveFlag()
        {
            var contact = getSelectedContact();
            if (contact != null)
                contact.IsActive = chkIsActive.Checked;
        }
    }
}
