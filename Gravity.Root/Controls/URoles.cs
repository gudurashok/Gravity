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
    public partial class URoles : UserControl
    {
        #region Declarations

        private IList<UserRoleEntity> _userRoleEntities;
        private UserRoleEntity _userRoleEntity;
        public event EventHandler<UserRoleEventArgs> UserRoleSaved;

        #endregion

        #region Constructor

        public URoles()
        {
            InitializeComponent();
        }

        #endregion

        #region Intialization

        public void Initialize()
        {
            buildColumns();
            txbName.PickList = PicklistFactory.UserRoles.Form;
            setButtonStates();
            txbName.ItemSelected += txbName_ItemSelected;
        }

        private void buildColumns()
        {
            lvwUserRoles.Columns.Add(new iColumnHeader("Name", true));
        }

        void txbName_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (e.PicklistItem == null) return;

            txbName.Text = txbName.Value == null ? null : ((UserRoleEntity)txbName.Value).Name;
        }

        #endregion

        #region Load User Roles

        public void LoadUserRoles(List<UserRoleEntity> userRoles)
        {
            _userRoleEntities = userRoles;
            refreshList();
        }

        #endregion

        #region Selected User Role Changed

        private void lvwResponsibilities_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedUserRole, sender, e);
        }

        void processSelectedUserRole(object sender, EventArgs e)
        {
            setButtonStates();
            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected) return;

            _userRoleEntity = getSelectedUserRole();
            txbName.Value = _userRoleEntity;
        }

        #endregion

        #region Remove User Role

        private void btnRemove_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processRemoveUserRole);
        }

        void processRemoveUserRole()
        {
            _userRoleEntity = getSelectedUserRole();
            _userRoleEntities.Remove(_userRoleEntity);
            OnUserRoleSaved(new UserRoleEventArgs((List<UserRoleEntity>)_userRoleEntities));
            refreshList();
        }

        #endregion

        #region Add UserRoles

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAddRoleResponsibilities);
        }

        void processAddRoleResponsibilities()
        {
            if (txbName.Value == null)
                throw new ValidationException(string.Format(Resources.UserRoleNameCannotBeEmpty));

            _userRoleEntity = (UserRoleEntity)txbName.Value;
            _userRoleEntities.Add(_userRoleEntity);
            txbName.Text = string.Empty;
            OnUserRoleSaved(new UserRoleEventArgs((List<UserRoleEntity>)_userRoleEntities));
            refreshList();
        }

        #endregion

        #region Save User Roles

        private void OnUserRoleSaved(UserRoleEventArgs e)
        {
            if (UserRoleSaved != null)
                UserRoleSaved(this, e);
        }

        #endregion

        #region Common

        void setButtonStates()
        {
            btnRemove.Enabled = lvwUserRoles.HasAnyItemsSelected();
            txbName.Value = lvwUserRoles.HasAnyItemsSelected() ? txbName.Value : null;
        }

        private void refreshList()
        {
            lvwUserRoles.FillData(_userRoleEntities);
            setButtonStates();
        }

        private UserRoleEntity getSelectedUserRole()
        {
            if (!lvwUserRoles.HasItems())
                return UserRoleEntity.New();

            return (UserRoleEntity)lvwUserRoles.SelectedItems[0].Tag;
        }

        #endregion
    }
}
