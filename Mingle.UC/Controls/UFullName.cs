using System;
using Scalable.Win.FormControls;
using Mingle.Domain.Model;

namespace Mingle.UC.Controls
{
    public partial class UFullName : UBaseForm
    {
        #region Declarations

        public event EventHandler NameChanged;
        private FullName _fullName;

        #endregion

        #region Constructor

        public UFullName()
        {
            InitializeComponent();
            _fullName = new FullName();
        }

        #endregion

        public override object DataSource
        {
            get
            {
                fillObject();
                return _fullName;
            }
            set
            {
                _fullName = value as FullName;
                fillForm();
            }
        }

        private void fillObject()
        {
            _fullName.First = txtFirst.Text.Trim();
            _fullName.Middle = txtMiddle.Text.Trim();
            _fullName.Last = txtLast.Text.Trim();
        }

        private void fillForm()
        {
            txtFirst.Text = _fullName.First;
            txtMiddle.Text = _fullName.Middle;
            txtLast.Text = _fullName.Last;
        }

        #region Get full names

        public string[] GetFullNames()
        {
            return _fullName.GetAllNames();
        }

        public override string ToString()
        {
            return _fullName.ToString();
        }

        #endregion

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            OnNameChanged(e);
        }
        
        protected virtual void OnNameChanged(EventArgs e)
        {
            if (NameChanged != null)
                NameChanged(this, e);
        }
    }
}
