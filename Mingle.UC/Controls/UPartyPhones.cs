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
    public partial class UPartyPhones : UBaseForm
    {
        private IList<Phone> _phones;

        public UPartyPhones()
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
            var oldValue = cmbType.Text;
            cmbType.DataSource = null;
            cmbType.DataSource = ReferenceList.GetList(ListType.PhoneTypes);
            cmbType.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Label", "Title", 100));
            ListView.Columns.Add(new iColumnHeader("Nr", "Number", true));
        }

        public override object DataSource
        {
            get
            {
                return _phones;
            }
            set
            {
                _phones = (value as IList<Phone>).Select(p => p).ToList();
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
            ListView.FillData(_phones.OrderByDescending(p => p.IsPreferred));
            ListView.BoldListItem(ListView.Items.Cast<ListViewItem>().SingleOrDefault(i => ((Phone) i.Tag).IsPreferred));
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
            var phone = ListView.HasAnyItemsSelected() ? getSelectedPhone() : new Phone();
            cmbType.Text = phone.Label;
            txtNr.Text = phone.ToString();
            chkIsActive.Checked = phone.IsActive;
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
            EventHandlerExecutor.Execute(addPhone);
        }

        void addPhone()
        {
            var phone = new Phone();
            fillPhone(phone);
            validate(phone);
            _phones.Add(phone);
            fillList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updatePhone);
        }

        private void updatePhone()
        {
            var phone = getSelectedPhone();
            fillPhone(phone);
            validate(phone);
            fillList();
        }

        private void validate(Phone phone)
        {
            phone.Validate();
            var selectedPhone = _phones.Where(p => p != phone)
                                    .SingleOrDefault(p => p.Label == cmbType.Text.Trim() &&
                                                        p.ToString() == txtNr.Text.Trim());

            if (selectedPhone != null)
                throw new ValidationException(Resources.NumberWithSameTitleAlreadyExist);
        }

        private void fillPhone(Phone phone)
        {
            phone.Label = cmbType.Text.Trim();
            phone.Nr = txtNr.Text.Trim();
            phone.IsActive = true;
        }

        private Phone getSelectedPhone()
        {
            return ListView.SelectedItems.Count > 0
                        ? (Phone)ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deletePhone);
        }

        private void deletePhone()
        {
            var phone = getSelectedPhone();
            _phones.Remove(phone);
            fillList();
            processItemSelection();
        }

        private void btnPreferred_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setPreferred);
        }

        void setPreferred()
        {
            foreach (var phone in _phones)
                phone.IsPreferred = false;

            var selectedPhone = getSelectedPhone();
            selectedPhone.IsPreferred = true;
            fillList();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setIsActiveFlag);
        }

        void setIsActiveFlag()
        {
            var phone = getSelectedPhone();
            if (phone != null)
                phone.IsActive = chkIsActive.Checked;
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
