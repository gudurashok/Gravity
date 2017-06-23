using System;
using Gravity.Root.Entities;
using Gravity.Root.Events;
using Gravity.Root.Model;
using Gravity.Root.Picklists;
using Gravity.Root.ViewModel;
using Scalable.Shared.Common;
using Scalable.Win.Events;
using Scalable.Win.FormControls;

namespace Gravity.Root.Controls
{
    public partial class UUser : UFormBase
    {
        #region Declarations

        private User _user;
        public event EventHandler<UserEventArgs> UserSaved;

        #endregion

        #region Constructor

        public UUser()
        {
            InitializeComponent();
        }

        #endregion

        #region Initialize form

        public void Initialize()
        {
            loadPicklists();
        }

        private void loadPicklists()
        {
            txbParentUser.PickList = PicklistFactory.UserHeirarchy.Form;
            txbParentUser.ItemSelected += txbParent_ItemSelected;
        }

        protected virtual void txbParent_ItemSelected(object sender, PicklistItemEventArgs e)
        {
            if (e.PicklistItem == null) return;
        }

        #endregion

        #region Data source

        public override object DataSource
        {
            get
            {
                fillObject();
                return _user;
            }
            set
            {
                _user = value as User;
                fillForm();
            }
        }

        private void fillForm()
        {
            txtUserName.Text = _user.Entity.Name;
            txtMobileNrs.Text = _user.Entity.MobileNrs;
            uCredentials.DataSource = _user.Entity.Credentials;
            txtDesignation.Text = _user.Entity.Designation;
            chkShowNotifications.Checked = _user.Entity.ShowNotifications;
            chkAllowAdHocNrs.Checked = _user.Entity.AllowAdHocNrs;
            chkIsAdmin.Checked = _user.Entity.IsAdmin;
            chkIsActive.Checked = _user.Entity.IsActive;
            txbParentUser.Value = getParentUserListItem();
        }

        private UserHeirarchyListItem getParentUserListItem()
        {
            return _user.Parent == null
                ? null
                : new UserHeirarchyListItem { User = _user.Parent };
        }

        private string getParentUserId()
        {
            return txbParentUser.Value == null
                       ? null
                       : ((UserHeirarchyListItem)txbParentUser.Value).User.Entity.Id;
        }

        private void fillObject()
        {
            _user.Entity.Name = txtUserName.Text;
            _user.Entity.MobileNrs = txtMobileNrs.Text;
            _user.Entity.Credentials = uCredentials.DataSource as Credentials;
            _user.Entity.Designation = txtDesignation.Text;
            _user.Entity.ShowNotifications = chkShowNotifications.Checked;
            _user.Entity.AllowAdHocNrs = chkAllowAdHocNrs.Checked;
            _user.Entity.IsAdmin = chkIsAdmin.Checked;
            _user.Entity.IsActive = chkIsActive.Checked;
            _user.Entity.ParentId = getParentUserId();
        }

        #endregion

        #region Save user

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveUser);
        }

        void saveUser()
        {
            var user = (User)DataSource;
            user.Save();
            OnUserSaved(new UserEventArgs(user.Entity));
        }

        protected virtual void OnUserSaved(UserEventArgs e)
        {
            if (UserSaved != null)
                UserSaved(this, e);
        }

        #endregion

        private void chkIsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            chkShowNotifications.Checked = !chkIsAdmin.Checked;
            chkAllowAdHocNrs.Checked = chkIsAdmin.Checked;

            chkShowNotifications.Enabled = !chkIsAdmin.Checked;
            chkAllowAdHocNrs.Enabled = !chkIsAdmin.Checked;
        }
    }
}
