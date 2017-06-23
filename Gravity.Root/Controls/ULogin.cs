using System;
using Gravity.Root.Entities;
using Gravity.Root.Events;
using Gravity.Root.Services;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;
using Gravity.Root.Common;
using Scalable.Shared.Enums;

namespace Gravity.Root.Controls
{
    public partial class ULogin : UFormBase
    {
        #region Declarations

        public event EventHandler<LoginEventArgs> Login;
        private bool _isRootLogin;

        #endregion

        #region Constructor

        public ULogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handlers

        public void Initialize(bool isRootLogin)
        {
            _isRootLogin = isRootLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processLogin, sender, e, clearPassword);
        }

        private void processLogin(object sender, EventArgs e)
        {
            var credentials = Credentials.New(txtLoginName.Text, txtPassword.Text);
            var user = _isRootLogin
                        ? AuthenticationService.AuthenticateWithRootCredentials(credentials)
                        : AuthenticationService.Authenticate(credentials);
            
            GravitySession.User = user;
            OnLogin(new LoginEventArgs(user));
        }

        private void clearPassword(EventHandlerExecutionResult result)
        {
            txtPassword.Clear();
        }

        protected virtual void OnLogin(LoginEventArgs e)
        {
            if (Login != null)
                Login(this, e);
        }

        #endregion
    }
}
