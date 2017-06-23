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
    public partial class UPartyProfessions : UBaseForm
    {
        private IList<string> _professions;

        public UPartyProfessions()
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
            var oldValue = cmbProfessions.Text;
            cmbProfessions.DataSource = null;
            cmbProfessions.DataSource = ReferenceList.GetList(ListType.Professions);
            cmbProfessions.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", "Profession", true));
        }

        public override object DataSource
        {
            get
            {
                return _professions;
            }
            set
            {
                _professions = (value as IList<string>).Select(n => n).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            ListView.FillData(_professions.Select(n => new { Name = n }).ToList());
            setControlStates();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddProfession);
        }

        void processAddProfession()
        {
            validate();
            _professions.Add(cmbProfessions.Text.Trim());
            fillForm();
        }

        private void validate()
        {
            if (string.IsNullOrWhiteSpace(cmbProfessions.Text.Trim()))
                throw new ValidationException(Resources.ProfessionCannotBeBlank);

            if (_professions.Contains(cmbProfessions.Text.Trim()))
                throw new ValidationException(Resources.ProfessionAlreadyExistForThisParty);
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setControlStates);
        }

        void setControlStates()
        {
            btnDelete.Enabled = ListView.HasOnlyOneItemSelected();
            cmbProfessions.Text = getSelectedProfession();
        }

        private string getSelectedProfession()
        {
            return ListView.HasAnyItemsSelected()
                        ? ListView.SelectedItems[0].Text
                        : string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteProfession);
        }

        void deleteProfession()
        {
            _professions.Remove(ListView.SelectedItems[0].Text);
            fillForm();
            setControlStates();
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
