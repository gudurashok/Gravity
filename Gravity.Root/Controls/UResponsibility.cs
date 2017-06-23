using System;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Forms;

namespace Gravity.Root.Controls
{
    public partial class UResponsibility : UListView
    {
        #region Declarations

        private RoleResponsibility _roleResponsibility;

        #endregion

        #region Constructor

        public UResponsibility()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialization

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new RoleResponsibilities();
            FillList(true);
            setButtonStates();
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
                return _roleResponsibility;
            }
            set
            {
                _roleResponsibility = value as RoleResponsibility;
                fillForm();
            }
        }

        private void fillObject()
        {
            _roleResponsibility.Entity.Name = txtName.Text;
            _roleResponsibility.Entity.IsActive = chkIsActive.Checked;
        }

        private void fillForm()
        {
            txtName.Text = _roleResponsibility.Entity.Name;
            chkIsActive.Checked = _roleResponsibility.Entity.IsActive;
        }

        #endregion

        #region Selected Role Responsibility

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            setButtonStates();
            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected) return;

            _roleResponsibility = getSelectedRoleResponsibility();
            DataSource = _roleResponsibility;
        }

        #endregion

        #region Role Responsibility Description

        private void btnDescription_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDescription);
        }

        void processDescription()
        {
            _roleResponsibility = new RoleResponsibility((RoleResponsibilityEntity)lvw.SelectedItems[0].Tag);
            var args = notesFormArgs(_roleResponsibility);
            var notesForm = new FNotes(args);
            if (notesForm.ShowDialog() != DialogResult.OK)
                return;

            _roleResponsibility.Entity.Description = args.Notes;
            _roleResponsibility.Save();
            refreshList();
        }

        private NotesFormArgs notesFormArgs(RoleResponsibility roleResponsibility)
        {
            var args = new NotesFormArgs();
            args.Caption = string.Format("Role Responsibilities: {0}", roleResponsibility.Entity.Name);
            args.Title = string.Format("Enter Description for Role Responsibilities {0}", roleResponsibility.Entity.Name);
            args.Notes = roleResponsibility.Entity.Description;
            return args;
        }

        #endregion

        #region  Delete Role Responsibility

        private void btnDelete_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processDelete);
        }

        void processDelete()
        {
            _roleResponsibility = getSelectedRoleResponsibility();

            var repo = new UserRepository();
            repo.DeleteRoleResponsibilityById(_roleResponsibility.Entity.Id);
            refreshList();
        }

        #endregion

        #region Add Role Responsibility

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processAdd);
        }

        void processAdd()
        {
            _roleResponsibility = RoleResponsibility.New();
            _roleResponsibility = (RoleResponsibility)DataSource;

            _roleResponsibility.Save();
            refreshList();
            lvw.SelectLastItem(true);
        }

        #endregion

        #region Update Role Responsibility

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processUpdate);
        }

        void processUpdate()
        {
            _roleResponsibility = getSelectedRoleResponsibility();
            _roleResponsibility = (RoleResponsibility)DataSource;

            _roleResponsibility.Save();
            refreshList();
        }

        #endregion

        #region Common

        private void setButtonStates()
        {
            btnUpdate.Enabled = lvw.HasAnyItemsSelected();
            btnDescription.Enabled = lvw.HasAnyItemsSelected();
            btnDelete.Enabled = lvw.HasAnyItemsSelected();
            txtName.Text = lvw.HasAnyItemsSelected() ? txtName.Text : string.Empty;
        }

        private RoleResponsibility getSelectedRoleResponsibility()
        {
            if (!lvw.HasAnyItemsSelected())
                return RoleResponsibility.New();

            return new RoleResponsibility((RoleResponsibilityEntity)lvw.SelectedItems[0].Tag);
        }

        private void refreshList()
        {
            FillList(true);
            setButtonStates();
        }
        #endregion
    }
}
