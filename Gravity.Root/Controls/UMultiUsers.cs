using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Gravity.Root.ViewModel;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Gravity.Root.Controls
{
    public partial class UMultiUsers : UBaseForm
    {
        private IList<User> _selectedUsers;
        private IList<User> _users;
        public event EventHandler UsersSelected;

        public UMultiUsers()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            _users = new Users().GetAllUsers();
            buildColumns();
        }

        private void buildColumns()
        {
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Parent", true));
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _selectedUsers;
            }
            set
            {
                _selectedUsers = value as IList<User>;
                fillForm();
            }
        }

        private void fillObject()
        {
            _selectedUsers = ListView.CheckedItems.Cast<ListViewItem>()
                                    .Select(i => ((UserHeirarchyListItem)i.Tag).User).ToList();
        }

        private void fillForm()
        {
            ListView.FillData(_users.Select(getUserListItem).OrderBy(u => u.Name).ToList());
            setCommandButtonStates();
            setCheckedIfSelected();
        }

        private void setCheckedIfSelected()
        {
            if (_selectedUsers == null || _selectedUsers.Count == 0)
                return;

            foreach (var item in _selectedUsers.SelectMany(selectedUser => ListView.Items.Cast<ListViewItem>().Where(item => selectedUser.Entity.Name == ((UserHeirarchyListItem)item.Tag).Name)))
                item.Checked = true;
        }

        private void setCommandButtonStates()
        {
            btnInvertSelection.Enabled = ListView.HasItems();
            btnOK.Enabled = ListView.HasItems();
        }

        private UserHeirarchyListItem getUserListItem(User user)
        {
            return new UserHeirarchyListItem { User = user };
        }

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(invertSelection);
        }

        void invertSelection()
        {
            foreach (ListViewItem item in ListView.Items)
                item.Checked = !item.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processOK);
        }

        void processOK()
        {
            OnUsersSelected(new EventArgs());
        }

        protected virtual void OnUsersSelected(EventArgs e)
        {
            if (UsersSelected != null)
                UsersSelected(this, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            var parent = Parent as Form;
            if (parent == null) return;
            parent.DialogResult = DialogResult.Cancel;
        }
    }
}
