using System;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Gravity.Root.Events;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Gravity.Root.Controls
{
    public partial class UUsers : UPicklist
    {
        #region Constructors

        public UUsers()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialize

        public override void Initialize()
        {
            SearchProperty = "Name";
            disableUserEntryForNonAdminUser();
            buildColumns();
            Repository = new Users();
            FillList();
            uUser.Initialize();
            uUser.UserSaved += uUser_UserSaved;
            Focus();
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Designation", 110));
        }

        private void disableUserEntryForNonAdminUser()
        {
            btnOpen.Visible = GravitySession.User.Entity.IsAdmin;
        }

        #endregion

        #region Select User

        private void lvw_ItemSelectionChanged(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            setButtonStates();
            if (uUser.Enabled)
                return;

            uUser.DataSource = getSelectedUser();
        }

        private void setButtonStates()
        {
            btnOpen.Enabled = lvw.HasAnyItemsSelected() && !getSelectedUser().IsAdministratorUser();
        }

        #endregion

        #region Open User

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            if (!GravitySession.User.Entity.IsAdmin)
                return;

            base.OnItemOpened(e);
        }

        #endregion

        #region New User

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewUser);
        }

        void processNewUser()
        {
            btnCancel.Enabled = true;
            uUser.Enabled = true;
            uUser.DataSource = User.New();
        }

        #endregion

        #region Edit User

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditUser);
        }

        void processEditUser()
        {
            btnCancel.Enabled = true;
            uUser.Enabled = true;
            uUser.DataSource = getSelectedUser();
        }

        #endregion

        #region Cancel Action

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            btnCancel.Enabled = false;
            uUser.Enabled = false;
            uUser.DataSource = getSelectedUser();
        }

        #endregion

        #region Common

        private User getSelectedUser()
        {
            if (!lvw.HasAnyItemsSelected())
                return User.New();

            return new User((UserEntity)lvw.SelectedItems[0].Tag);
        }

        #endregion

        #region On Saving

        protected virtual void uUser_UserSaved(object sender, UserEventArgs e)
        {
            uUser.Enabled = false;
            btnCancel.Enabled = false;
            FillList(true);
        }

        #endregion

        #region User options

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processOptions);
        }

        void processOptions()
        {
            var optionsForm = new FOptions(new EntityListRepository());
            optionsForm.ShowDialog();
        }

        #endregion
    }
}
