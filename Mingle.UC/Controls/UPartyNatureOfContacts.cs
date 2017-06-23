using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.UC.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyNatureOfContacts : UBaseForm
    {
        private IList<string> _natureOfContacts;

        public UPartyNatureOfContacts()
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
            var oldValue = cmbNatureOfContacts.Text;
            cmbNatureOfContacts.DataSource = null;
            cmbNatureOfContacts.DataSource = ReferenceList.GetList(ListType.NatureOfContacts);
            cmbNatureOfContacts.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", "Nature of contact", true));
        }

        public override object DataSource
        {
            get
            {
                return _natureOfContacts;
            }
            set
            {
                _natureOfContacts = (value as IList<string>).Select(n => n).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            ListView.FillData(_natureOfContacts.Select(n => new { Name = n }).ToList());
            setControlStates();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddNatureOfContact);
        }

        void processAddNatureOfContact()
        {
            validate();
            _natureOfContacts.Add(cmbNatureOfContacts.Text.Trim());
            fillForm();
        }

        private void validate()
        {
            if (string.IsNullOrWhiteSpace(cmbNatureOfContacts.Text.Trim()))
                throw new ValidationException(Resources.NatureOfContactCannotBeBlank);

            if (_natureOfContacts.Contains(cmbNatureOfContacts.Text.Trim()))
                throw new ValidationException(Resources.NatureOfContactAlreadyExistForThisParty);
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setControlStates);
        }

        void setControlStates()
        {
            btnDelete.Enabled = ListView.HasOnlyOneItemSelected();
            cmbNatureOfContacts.Text = getSelectedNatureOfContact();
        }

        private string getSelectedNatureOfContact()
        {
            return ListView.HasAnyItemsSelected()
                        ? ListView.SelectedItems[0].Text
                        : string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteNatureOfContact);
        }

        void deleteNatureOfContact()
        {
            _natureOfContacts.Remove(ListView.SelectedItems[0].Text);
            fillForm();
            setControlStates();
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
