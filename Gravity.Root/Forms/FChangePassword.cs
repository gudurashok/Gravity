using System;
using System.Windows.Forms;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Win.Forms;

namespace Gravity.Root.Forms
{
    public partial class FChangePassword : FFormBase
    {
        public FChangePassword()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            setFormTitle();
            uChangePassword.Initialize();
            uChangePassword.PasswordChanged += uChangePassword_ChangePassword;
        }

        private void setFormTitle()
        {
            Text = getFormTitle();
            lblTitle.Text = getTitleText();
        }

        private static string getFormTitle()
        {
            return string.Format("Change password");
        }

        private string getTitleText()
        {
            return string.Format("Enter change password details");
        }

        void uChangePassword_ChangePassword(object sender, System.EventArgs e)
        {
            MessageBoxUtil.ShowMessage(string.Format("Password changed successfully"));
            Close();
        }
    }
}
