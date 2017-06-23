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
    public partial class UPartyLanguages : UBaseForm
    {
        private IList<string> _languages;

        public UPartyLanguages()
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
            var oldValue = cmbLanguages.Text;
            cmbLanguages.DataSource = null;
            cmbLanguages.DataSource = ReferenceList.GetList(ListType.Languages);
            cmbLanguages.Text = oldValue;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", "Language", true));
        }

        public override object DataSource
        {
            get
            {
                return _languages;
            }
            set
            {
                _languages = (value as IList<string>).Select(l => l).ToList();
                fillForm();
            }
        }

        private void fillForm()
        {
            ListView.FillData(_languages.Select(l => new { Name = l }).ToList());
            setControlStates();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddLanguage);
        }

        void processAddLanguage()
        {
            validate();
            _languages.Add(cmbLanguages.Text.Trim());
            fillForm();
        }

        void validate()
        {
            if (string.IsNullOrWhiteSpace(cmbLanguages.Text.Trim()))
                throw new ValidationException(Resources.LanguageCannotBeBlank);

            if (_languages.Contains(cmbLanguages.Text.Trim()))
                throw new ValidationException(Resources.LanguageAlreadyExistForThisParty);
        }

        private void lvw_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setControlStates);
        }

        void setControlStates()
        {
            btnDelete.Enabled = ListView.HasOnlyOneItemSelected();
            cmbLanguages.Text = getSelectedLanguage();
        }

        private string getSelectedLanguage()
        {
            return ListView.HasAnyItemsSelected()
                        ? ListView.SelectedItems[0].Text
                        : string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(deleteLanguage);
        }

        void deleteLanguage()
        {
            _languages.Remove(ListView.SelectedItems[0].Text);
            fillForm();
            setControlStates();
        }

        public void RefreshForm()
        {
            fillDropDowns();
        }
    }
}
