using System.ComponentModel.DataAnnotations;
using Gravity.Root.Entities;
using Gravity.Root.Properties;
using Scalable.Win.FormControls;

namespace Gravity.Root.Controls
{
    public partial class UCredentials : UBaseForm
    {
        #region Declarations

        private Credentials _credentials;

        #endregion

        #region Constructor

        public UCredentials()
        {
            InitializeComponent();
        }

        #endregion

        #region Datasource

        public override object DataSource
        {
            get
            {
                fillObject();
                return _credentials;
            }
            set
            {
                _credentials = value as Credentials;
                fillForm();
            }
        }
 
        private void fillObject()
        {
            if (!Credentials.IsPasswordConfirms(txtPassword.Text, txtConfirmPassword.Text))
            {
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
                txtConfirmPassword.Select();
                throw new ValidationException(Resources.PasswordsNotMatching);
            }

            _credentials = Credentials.New(txtLoginName.Text, txtPassword.Text);
        }

        private void fillForm()
        {
            txtLoginName.Text = _credentials.LoginName;
            txtPassword.Text = _credentials.Password;
            txtConfirmPassword.Text = _credentials.Password;
        }

        #endregion
    }
}
