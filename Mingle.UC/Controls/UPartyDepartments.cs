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
    public partial class UPartyDepartments : UBaseForm
    {
        private IList<string> _departments;

        public UPartyDepartments()
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
            var oldValue = cmbDepartments.Text;
            cmbDepartments.DataSource = null;
            cmbDepartments.DataSource = ReferenceList.GetList(ListType.Departments);
            cmbDepartments.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", "Department", true));
        }

        public override object DataSource
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = (value as IList<string>).Select(d => d).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            ListView.FillData(_departments.Select(d => new { Name = d }).ToList());
            setControlStates();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddDepartment);
        }

        void processAddDepartment()
        {
            validate();
            _departments.Add(cmbDepartments.Text.Trim());
            fillForm();
        }

        private void validate()
        {
            if (string.IsNullOrWhiteSpace(cmbDepartments.Text.Trim()))
                throw new ValidationException(Resources.DepartmentCannotBeBlank);

            if (_departments.Contains(cmbDepartments.Text.Trim()))
                throw new ValidationException(Resources.DepartmentAlreadyExistForThisParty);
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setControlStates);
        }

        void setControlStates()
        {
            btnDelete.Enabled = ListView.HasOnlyOneItemSelected();
            cmbDepartments.Text = getSelectedDepartment();
        }

        private string getSelectedDepartment()
        {
            return ListView.HasAnyItemsSelected()
                        ? ListView.SelectedItems[0].Text
                        : string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteDepartment);
        }

        void deleteDepartment()
        {
            _departments.Remove(ListView.SelectedItems[0].Text);
            fillForm();
            setControlStates();
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
