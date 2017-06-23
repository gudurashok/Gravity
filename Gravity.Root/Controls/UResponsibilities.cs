using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Gravity.Root.Events;
using Gravity.Root.Picklists;
using Gravity.Root.Properties;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.Events;

namespace Gravity.Root.Controls
{
    public partial class UResponsibilities : UserControl
    {
        #region Declarations

        private IList<RoleResponsibilityEntity> _roleResponsibilities;
        private RoleResponsibilityEntity _roleResponsibilityEntity;
        public event EventHandler<ResponsibilityEventArgs> ResponsibilitySaved;

        #endregion

        #region Constructor

        public UResponsibilities()
        {
            InitializeComponent();
        }

        #endregion

        #region Intialization

        public void Initialize()
        {
            buildColumns();
            txbName.PickList = PicklistFactory.RoleResponsibilities.Form;
            setButtonStates();
            txbName.ItemSelected += txbName_ItemSelected;
        }

        private void buildColumns()
        {
            lvwResponsibilities.Columns.Add(new iColumnHeader("Name", true));
        }

        void txbName_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (e.PicklistItem == null) return;

            txbName.Text = txbName.Value == null ? null : ((RoleResponsibilityEntity)txbName.Value).Name;
        }

        #endregion

        #region Load Role Responsibilities

        public void LoadResponsibilities(List<RoleResponsibilityEntity> roleResponsibilities)
        {
            _roleResponsibilities = roleResponsibilities;
            refreshList();
        }

        #endregion

        #region Selected Role Responsibility Changed

        private void lvwResponsibilities_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedRoleResponsibility, sender, e);
        }

        void processSelectedRoleResponsibility(object sender, EventArgs e)
        {
            setButtonStates();
            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected) return;

            _roleResponsibilityEntity = getSelectedRoleResponsibility();
            txbName.Value = _roleResponsibilityEntity;
        }

        #endregion

        #region Remove Responsibilities

        private void btnRemove_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processRemoveResponsibility);
        }

        void processRemoveResponsibility()
        {
            _roleResponsibilityEntity = getSelectedRoleResponsibility();
            _roleResponsibilities.Remove(_roleResponsibilityEntity);
            OnResponsibilitySaved(new ResponsibilityEventArgs((List<RoleResponsibilityEntity>)_roleResponsibilities));
            refreshList();
        }

        #endregion

        #region Add Responsibilities

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddRoleResponsibilities);
        }

        void processAddRoleResponsibilities()
        {
            if (txbName.Value == null)
                throw new ValidationException(string.Format(Resources.ResponsibilityNameCannotBeEmpty));

            _roleResponsibilityEntity = (RoleResponsibilityEntity)txbName.Value;
            _roleResponsibilities.Add(_roleResponsibilityEntity);
            txbName.Text = string.Empty;
            OnResponsibilitySaved(new ResponsibilityEventArgs((List<RoleResponsibilityEntity>)_roleResponsibilities));
            refreshList();
        }

        #endregion

        private void OnResponsibilitySaved(ResponsibilityEventArgs e)
        {
            if (ResponsibilitySaved != null)
                ResponsibilitySaved(this, e);
        }

        #region Common

        void setButtonStates()
        {
            btnRemove.Enabled = lvwResponsibilities.HasAnyItemsSelected();
            txbName.Value = lvwResponsibilities.HasAnyItemsSelected() ? txbName.Value : null;
        }

        private void refreshList()
        {
            lvwResponsibilities.FillData(_roleResponsibilities);
            setButtonStates();
        }

        private RoleResponsibilityEntity getSelectedRoleResponsibility()
        {
            if (!lvwResponsibilities.HasItems())
                return RoleResponsibilityEntity.New();

            return (RoleResponsibilityEntity)lvwResponsibilities.SelectedItems[0].Tag;
        }

        #endregion
    }
}
