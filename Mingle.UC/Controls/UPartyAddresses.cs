using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Mingle.UC.Common;
using Mingle.UC.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPartyAddresses : UBaseForm, IParty
    {
        public UBaseForm Control { get; private set; }
        private Party _party;
        private IList<PartyAddress> _addresses;

        public UPartyAddresses()
        {
            InitializeComponent();
            Control = this;
        }

        public void Initialize()
        {
            buildColumns();
            fillDropDowns();
            uAddress.Initialize();
            uAddress.DataSource = new PartyAddress();
        }

        private void fillDropDowns()
        {
            fillAddressTypes();
            fillAddressUsageTypes();
        }

        private void fillAddressTypes()
        {
            var oldValue = cmbTitle.Text;
            cmbTitle.DataSource = null;
            cmbTitle.DataSource = ReferenceList.GetList(ListType.AddressTypes);
            cmbTitle.Text = oldValue;
        }

        private void fillAddressUsageTypes()
        {
            var oldValue = cmbUsageType.Text;
            cmbUsageType.DataSource = null;
            cmbUsageType.DataSource = ReferenceList.GetList(ListType.AddressUsageTypes);
            cmbUsageType.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Label", "Title", 120));
            ListView.Columns.Add(new iColumnHeader("UsageLabel", "Usage", 120));
            ListView.Columns.Add(new iColumnHeader("AddressString", "Address", true));
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
            _addresses = _party.Entity.Addresses.Select(a => a).ToList();
            fillList();
            processSelectedAddress();
        }

        private void fillList()
        {
            ListView.FillData(_addresses.OrderByDescending(a => a.IsPreferred));
            ListView.BoldListItem(ListView.Items.Cast<ListViewItem>().SingleOrDefault(i => ((PartyAddress)i.Tag).IsPreferred));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(addAddress);
        }

        void addAddress()
        {
            var address = uAddress.GetCopy();

            fillAddress(address);
            validate(address);
            _addresses.Add(address);
            fillList();
        }

        private void validate(PartyAddress address)
        {
            address.Validate();
            var selectedAddress = _addresses
                                    .Where(a => a != address)
                                    .SingleOrDefault(e => e.Label == cmbTitle.Text.Trim() &&
                                                        e.UsageLabel == cmbUsageType.Text.Trim() &&
                                                        e.AddressString == uAddress.DataSource.ToString());
            if (selectedAddress != null)
                throw new ValidationException(Resources.AddressWithSameTitleAlreadyExist);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateAddress);
        }

        void updateAddress()
        {
            var address = (PartyAddress)uAddress.DataSource;
            fillAddress(address);
            validate(address);
            fillList();
        }

        private void fillAddress(PartyAddress address)
        {
            address.Label = cmbTitle.Text;
            address.UsageLabel = cmbUsageType.Text;
            address.IsActive = true;
        }

        private PartyAddress getSelectedAddress()
        {
            return ListView.SelectedItems.Count > 0
                        ? (PartyAddress)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteAddress);
        }

        void deleteAddress()
        {
            _addresses.Remove(getSelectedAddress());
            fillList();
            processSelectedAddress();
        }

        private void btnPreferred_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setAddressPreferred);
        }

        void setAddressPreferred()
        {
            foreach (var address in _addresses)
                address.IsPreferred = false;

            var selectedAddress = getSelectedAddress();
            selectedAddress.IsPreferred = true;
            fillList();
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedAddress);
        }

        void processSelectedAddress()
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
            var address = ListView.HasAnyItemsSelected() ? getSelectedAddress() : new PartyAddress();
            uAddress.DataSource = address;
            cmbTitle.Text = address.Label;
            cmbUsageType.Text = address.UsageLabel;
        }

        public void Save()
        {
            _party.Entity.Addresses = _addresses;
        }

        public void RefreshLists()
        {
            fillDropDowns();
            uAddress.RefreshLists();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setIsActiveFlag);
        }

        void setIsActiveFlag()
        {
            var address = getSelectedAddress();
            if (address != null)
                address.IsActive = chkIsActive.Checked;
        }
    }
}
