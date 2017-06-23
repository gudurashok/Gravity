using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Events;
using Scalable.Shared.Common;
using Scalable.Win.Common;
using Scalable.Win.Forms;

namespace Gravity.Root.Forms
{
    public partial class FLogin : FFormBase
    {
        #region Declarations

        private readonly bool _isRootLogin;
        private readonly ScalableApplicationBase _application;

        #endregion

        #region Contructors

        public FLogin()
        {
            InitializeComponent();
        }

        public FLogin(ScalableApplicationBase application, bool isRootLogin = false)
            : this()
        {
            _application = application;
            _isRootLogin = isRootLogin;
        }

        #endregion

        #region Load

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Text = string.Format(_isRootLogin ? "{0} Root Login" : "{0} Login", GravityApplication.GetProductName());
            lblTitle.Text = getFormTitle();
            SetForegroundWindow(Handle);
            lnkChangePassword.Visible = !_isRootLogin;
            BringToFront();
            uLogin.Initialize(_isRootLogin);
            _application.HideSplash();
        }

        private string getFormTitle()
        {
            return _isRootLogin ? string.Format("Enter login credentials for Root login")
                                : string.Format("{0}:\rEnter your login credentials",
                                                GravitySession.CompanyGroup.Entity.Name);
        }

        [DllImport("user32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        #endregion

        #region Login

        private void uLogin_Login(object sender, LoginEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Change password

        private void lnkChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHandlerExecutor.Execute(processChangePassword);
        }

        void processChangePassword()
        {
            var changePasswordForm = new FChangePassword();
            changePasswordForm.ShowDialog();
        }

        #endregion
    }
}
