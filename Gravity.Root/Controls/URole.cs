using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Gravity.Root.Events;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;

namespace Gravity.Root.Controls
{
    public partial class URole : UListView
    {
        #region Declarations

        private UserRoleModel _userRoleModel;

        #endregion

        #region Constructor

        public URole()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialization

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new UserRoles();
            FillList(true);
            setButtonStates();
            uRoleResponsibility.Initialize();
            uRoleResponsibility.ResponsibilitySaved += uRoleResponsibility_ResponsibilitySaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", true));
        }

        #endregion

        #region DataSource

        public override object DataSource
        {
            get
            {
                fillObject();
                return _userRoleModel;
            }
            set
            {
                _userRoleModel = value as UserRoleModel;
                fillForm();
            }
        }

        private void fillObject()
        {
            _userRoleModel.Entity.Name = txtName.Text;
            _userRoleModel.Entity.IsActive = chkIsActive.Checked;
        }

        private void fillForm()
        {
            txtName.Text = _userRoleModel.Entity.Name;
            chkIsActive.Checked = _userRoleModel.Entity.IsActive;
        }

        #endregion

        #region Selected User Role

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            setButtonStates();
            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected) return;

            _userRoleModel = getSelectedUserRole();
            DataSource = _userRoleModel;
            uRoleResponsibility.LoadResponsibilities((List<RoleResponsibilityEntity>)_userRoleModel.Entity.Responsibilities);
        }

        #endregion

        #region Role Responsibility Description

        private void btnDescription_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDescription);
        }

        void processDescription()
        {
            _userRoleModel = getSelectedUserRole();
            var args = notesFormArgs(_userRoleModel);
            var notesForm = new FNotes(args);
            if (notesForm.ShowDialog() != DialogResult.OK)
                return;

            _userRoleModel.Entity.Description = args.Notes;
            _userRoleModel.Save();
            refreshList();
        }

        private NotesFormArgs notesFormArgs(UserRoleModel userRoleModel)
        {
            var args = new NotesFormArgs();
            args.Caption = string.Format("User Role: {0}", userRoleModel.Entity.Name);
            args.Title = string.Format("Enter Description for User Role {0}", userRoleModel.Entity.Name);
            args.Notes = userRoleModel.Entity.Description;
            return args;
        }

        #endregion

        #region  Delete User Role

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDelete);
        }

        void processDelete()
        {
            _userRoleModel = getSelectedUserRole();

            var repo = new UserRepository();
            repo.DeleteUserRoleById(_userRoleModel.Entity.Id);
            refreshList();
        }

        #endregion

        #region Add User Role

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAdd);
        }

        void processAdd()
        {
            _userRoleModel = UserRoleModel.New();
            SaveUserRole(_userRoleModel);
            lvw.SelectLastItem(true);
        }

        private void SaveUserRole(UserRoleModel userRole)
        {
            userRole = (UserRoleModel)DataSource;
            userRole.Save();
            refreshList();
        }

        #endregion

        #region Update User Role

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processUpdate);
        }

        void processUpdate()
        {
            _userRoleModel = getSelectedUserRole();
            SaveUserRole(_userRoleModel);
        }

        #endregion

        #region Common

        private void setButtonStates()
        {
            btnUpdate.Enabled = lvw.HasAnyItemsSelected();
            btnDescription.Enabled = lvw.HasAnyItemsSelected();
            btnDelete.Enabled = lvw.HasAnyItemsSelected();
            txtName.Text = lvw.HasAnyItemsSelected() ? txtName.Text : string.Empty;

            uRoleResponsibility.Enabled = lvw.HasAnyItemsSelected();
        }

        private UserRoleModel getSelectedUserRole()
        {
            if (!lvw.HasAnyItemsSelected())
                return new UserRoleModel(UserRoleEntity.New());

            return new UserRoleModel((UserRoleEntity)lvw.SelectedItems[0].Tag);
        }

        private void refreshList()
        {
            FillList(true);
            setButtonStates();
        }
        #endregion

        #region Event when Role Responisibilty saved

        protected virtual void uRoleResponsibility_ResponsibilitySaved(object sender, ResponsibilityEventArgs e)
        {
            _userRoleModel.Entity.Responsibilities = e.RoleResponsibilityEntities;
            _userRoleModel = (UserRoleModel)DataSource;

            _userRoleModel.Save();
            refreshList();
        }

        #endregion
    }
}
