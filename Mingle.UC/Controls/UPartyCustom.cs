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
    public partial class UPartyCustom : UBaseForm
    {
        private IList<CustomProperty> _customProps;

        public UPartyCustom()
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
            var oldValue = cmbName.Text;
            cmbName.DataSource = null;
            cmbName.DataSource = ReferenceList.GetList(ListType.CustomTypes);
            cmbName.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", 100));
            ListView.Columns.Add(new iColumnHeader("Value", true));
        }

        public override object DataSource
        {
            get
            {
                return _customProps;
            }
            set
            {
                _customProps = (value as IList<CustomProperty>).Select(c => c).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            ListView.FillData(_customProps);
            processItemSelection();
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
            var prop = ListView.HasAnyItemsSelected() ? getSelectedProperty() : new CustomProperty();
            cmbName.Text = prop.Name;
            txtValue.Text = prop.ToString();
        }

        private void setCommandButtonStates()
        {
            btnUpdate.Enabled = ListView.HasAnyItemsSelected();
            btnDelete.Enabled = ListView.HasAnyItemsSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(addProp);
        }

        void addProp()
        {
            var prop = new CustomProperty();
            fillProp(prop);
            validate(prop);
            _customProps.Add(prop);
            fillForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(updateProp);
        }

        private void updateProp()
        {
            var prop = getSelectedProperty();
            fillProp(prop);
            validate(prop);
            fillForm();
        }

        private void validate(CustomProperty prop)
        {
            prop.Validate();
            var selectedProp = _customProps
                                .Where(p => p != prop)
                                .SingleOrDefault(e => e.Name == cmbName.Text.Trim() &&
                                                    e.ToString() == txtValue.Text.Trim());
            if (selectedProp != null)
                throw new ValidationException(Resources.PropertyWithSameTitleAlreadyExist);
        }

        private void fillProp(CustomProperty prop)
        {
            prop.Name = cmbName.Text.Trim();
            prop.Value = txtValue.Text.Trim();
        }

        private CustomProperty getSelectedProperty()
        {
            return ListView.SelectedItems.Count > 0
                        ? (CustomProperty) ListView.SelectedItems[0].Tag
                        : null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteProp);
        }

        private void deleteProp()
        {
            var prop = getSelectedProperty();
            _customProps.Remove(prop);
            fillForm();
            processItemSelection();
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
