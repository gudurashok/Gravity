using System;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Entities;
using Gravity.Root.Properties;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Gravity.Root.Controls
{
    public partial class UChangePassword : UFormBase
    {
        private Credentials _credentials;
        public event EventHandler PasswordChanged;

        public UChangePassword()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            _credentials = new Credentials();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processOkButton);
        }

        void processOkButton()
        {
            validatePasswordAndConfirmPassword();
            _credentials.LoginName = txtLoginName.Text;
            _credentials.Password = string.IsNullOrWhiteSpace(txtNewPassword.Text) ? null : txtNewPassword.Text;
            saveUser();
            OnPasswordChanged(new EventArgs());
        }

        private void saveUser()
        {
            var repo = new Users();
            var user = repo.GetByLoginName(_credentials.LoginName);

            if (user == null)
                throw new ValidationException(string.Format(Resources.InvalidLoginName));

            var oldPassword = user.Entity.Credentials.Password ?? string.Empty;

            checkIfEnteredPasswordCorrect(oldPassword);
            user.Entity.Credentials = _credentials;
            user.Save();
        }

        private void checkIfEnteredPasswordCorrect(string password)
        {
            if (Credentials.IsPasswordConfirms(txtPassword.Text, password))
                return;

            txtPassword.Text = string.Empty;
            throw new ValidationException(string.Format(Resources.PasswordsNotMatching));
        }

        private void validatePasswordAndConfirmPassword()
        {
            if (Credentials.IsPasswordConfirms(txtNewPassword.Text, txtConfirmPassword.Text))
                return;

            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            throw new ValidationException(string.Format(Resources.PasswordAndConfirmPasswordIsNotMatching));
        }

        protected virtual void OnPasswordChanged(EventArgs e)
        {
            if (PasswordChanged != null)
                PasswordChanged(this, e);
        }
    }
}
