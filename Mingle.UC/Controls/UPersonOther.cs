using System;
using System.Collections.Generic;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Mingle.UC.Controls
{
    public partial class UPersonOther : UBaseForm
    {
        private Party _party;

        public UPersonOther()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            loadDropDowns();
            uPartyLanguages.Initialize();
            uPartyRelations.Initialize();
        }

        private void loadDropDowns()
        {
            EnumUtil.LoadEnumListItems(cmbGender, typeof(Gender), Gender.Unknown);
            EnumUtil.LoadEnumListItems(cmbBloodGroup, typeof(BloodGroup), BloodGroup.Unknown);
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
            txtNickName.Text = _party.Entity.Nickname;
            EnumUtil.SetEnumListItem(cmbGender, _party.Entity.Gender);
            EnumUtil.SetEnumListItem(cmbBloodGroup, _party.Entity.BloodGroup);
            uPartyLanguages.DataSource = _party.Entity.Languages;
            uPartyRelations.DataSource = _party.Entity.Relations;
        }

        public void Save()
        {
            _party.Entity.Nickname = txtNickName.Text.Trim();
            _party.Entity.Gender = (Gender)cmbGender.SelectedValue;
            _party.Entity.BloodGroup = (BloodGroup)cmbBloodGroup.SelectedValue;
            _party.Entity.Languages = uPartyLanguages.DataSource as IList<string>;
            _party.Entity.Relations = uPartyRelations.DataSource as IList<PersonRelation>;
        }

        public void RefreshForm()
        {
            uPartyLanguages.RefreshForm();
            uPartyRelations.RefreshForm();
        }

        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(setDefault, sender);
        }

        void setDefault(object sender)
        {
            var control = (iComboBox)sender;
            if (control.SelectedIndex == -1 && control.Items.Count > 0)
                control.SelectedIndex = 0;
        }
    }
}
