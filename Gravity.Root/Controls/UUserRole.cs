using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Gravity.Root.Controls
{
    public partial class UUserRole : UListView
    {
        private User _user;

        public UUserRole()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new Users();
            FillList(true);
            setButtonStates();
            uUserRoleAssign.Initialize();
            uUserRoleAssign.UserRoleSaved += uUserRoleAssign_UserRoleSaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", true));
        }

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            setButtonStates();
            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected) return;

            _user = getSelectedUser();
            _user.Save();
            uUserRoleAssign.LoadUserRoles((List<UserRoleEntity>)_user.Entity.Roles);
        }

        private User getSelectedUser()
        {
            if (!lvw.HasAnyItemsSelected())
                return User.New();

            return new User((UserEntity)lvw.SelectedItems[0].Tag);
        }

        private void setButtonStates()
        {
            uUserRoleAssign.Enabled = lvw.HasAnyItemsSelected();
        }

        protected virtual void uUserRoleAssign_UserRoleSaved(object sender, Events.UserRoleEventArgs e)
        {
            _user.Entity.Roles = e.UserRoleEntities;
            _user.Save();
        }
    }
}
