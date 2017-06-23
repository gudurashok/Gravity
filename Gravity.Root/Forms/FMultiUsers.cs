using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gravity.Root.Model;
using Scalable.Win.Forms;

namespace Gravity.Root.Forms
{
    public partial class FMultiUsers : FFormBase
    {
        public IList<User> Users;

        public FMultiUsers()
            : this(new List<User>())
        {
        }

        public FMultiUsers(IList<User> users)
        {
            InitializeComponent();
            Users = users;
        }

        protected override void OnLoad(EventArgs e)
        {
            setFormTitle();
            uMultiUsers.Initialize();
            uMultiUsers.DataSource = Users;
            uMultiUsers.UsersSelected += uMultiUsers_UsersSelected;
        }

        void uMultiUsers_UsersSelected(object sender, EventArgs e)
        {
            Users = uMultiUsers.DataSource as List<User>;
            DialogResult = DialogResult.OK;
        }

        private void setFormTitle()
        {
            Text = getFormTitle();
            lblTitle.Text = getTitleText();
        }

        private static string getFormTitle()
        {
            return string.Format("Select Users");
        }

        private string getTitleText()
        {
            return string.Format("Select multiple users");
        }
    }
}
