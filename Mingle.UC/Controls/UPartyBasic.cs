using System;
using System.Collections.Generic;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.Domain.ViewModel;
using Mingle.UC.Common;
using Mingle.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyBasic : UBaseForm, IParty
    {
        public UBaseForm Control { get; private set; }
        private Party _party;

        public UPartyBasic()
        {
            InitializeComponent();
            Control = this;
            uFullName.NameChanged += uFullName_NameChanged;
            txtOrganizationName.Leave += txtOrganizationName_Leave;
        }

        void txtOrganizationName_Leave(object sender, EventArgs e)
        {
            uFullName.DataSource = new FullName(txtOrganizationName.Text.Trim());
        }

        void uFullName_NameChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNameChanged);
        }

        void processNameChanged()
        {
            txtOrganizationName.Text = uFullName.DataSource.ToString();
        }

        public override object DataSource
        {
            get
            {
                return _party;
            }
            set
            {
                _party = value as Party;
                fillForm();
            }
        }

        private void fillForm()
        {
            EnumUtil.SetEnumListItem(cmbPartyType, _party.Entity.Type);
            cmbSalutation.Text = _party.Entity.Salutation;
            setPartyName();
            setGroup();
            txtShortName.Text = _party.Entity.ShortName;
            txtAliasName.Text = _party.Entity.AliasName;
            uPartyNatureOfContacts.DataSource = _party.Entity.NatureOfContacts;
            uPartyPhones.DataSource = _party.Entity.Phones;
        }

        private void setGroup()
        {
            txbGroup.Value = _party.Parent == null ? null : new PartyListItem { Party = _party.Parent };
        }

        private void setPartyName()
        {
            uFullName.DataSource = isPerson() ? _party.Entity.FullName : new FullName(_party.Entity.Name);
            txtOrganizationName.Text = isPerson() ? _party.Entity.FullName.ToString() : _party.Entity.Name;
        }

        public void Initialize()
        {
            EnumUtil.LoadEnumListItems(cmbPartyType, typeof(PartyType), PartyType.Person);
            txbGroup.PickList = PicklistFactory.Parties.Form;
            uPartyNatureOfContacts.Initialize();
            uPartyPhones.Initialize();
        }

        private void cmbPartyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(resetSalutation);
        }

        void resetSalutation()
        {
            if (cmbPartyType.SelectedIndex == -1 && cmbPartyType.Items.Count > 0)
                cmbPartyType.SelectedIndex = 0;

            setNameControlsStatus();
            cmbSalutation.Text = string.Empty;
            if (_party == null) return;
            _party.Entity.Type = (PartyType)cmbPartyType.SelectedValue;
        }

        private void setNameControlsStatus()
        {
            uFullName.Visible = isPerson();
            txtOrganizationName.Visible = !uFullName.Visible;
        }

        private void cmbSalutation_DropDown(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(fillSalutations);
        }

        void fillSalutations()
        {
            if (isPerson())
                fillPersonSalutations();
            else
                fillOrganizationSalutation();
        }

        private void fillPersonSalutations()
        {
            var oldValue = cmbSalutation.Text;
            cmbSalutation.DataSource = ReferenceList.GetList(ListType.Salutations);
            cmbSalutation.Text = oldValue;
        }

        private void fillOrganizationSalutation()
        {
            if (cmbSalutation.DataSource == null && cmbSalutation.Items.Count > 0)
                return;

            cmbSalutation.DataSource = null;
            cmbSalutation.Items.Add("M/s.");
        }

        private bool isPerson()
        {
            return (PartyType)cmbPartyType.SelectedValue == PartyType.Person;
        }

        public void Save()
        {
            _party.Entity.Type = (PartyType)cmbPartyType.SelectedValue;
            _party.Entity.Salutation = cmbSalutation.Text;
            getPartyName();
            getGroup();
            _party.Entity.ShortName = txtShortName.Text;
            _party.Entity.AliasName = txtAliasName.Text;
            _party.Entity.NatureOfContacts = uPartyNatureOfContacts.DataSource as IList<string>;
            _party.Entity.Phones = uPartyPhones.DataSource as IList<Phone>;
        }

        private void getPartyName()
        {
            _party.Entity.FullName = uFullName.DataSource as FullName;
            _party.Entity.Name = txtOrganizationName.Text;
        }

        private void getGroup()
        {
            _party.Parent = txbGroup.Value == null ? null : ((PartyListItem)txbGroup.Value).Party;
            _party.Entity.ParentId = _party.Parent == null ? null : _party.Parent.Entity.Id;
        }

        public void RefreshLists()
        {
            uPartyNatureOfContacts.RefreshForm();
            uPartyPhones.RefreshForm();
            refreshSalutations();
        }

        private void refreshSalutations()
        {
            if (!isPerson())
                return;

            var oldValue = cmbSalutation.Text;
            cmbSalutation.DataSource = null;
            cmbSalutation.DataSource = ReferenceList.GetList(ListType.Salutations);
            cmbSalutation.Text = oldValue;
        }
    }
}
