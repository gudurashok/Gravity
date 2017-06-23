using System;
using System.Windows.Forms;
using Gravity.Root.Events;
using Scalable.Win.Forms;

namespace Gravity.Root.Forms
{
    public partial class FCompanyGroups : FFormBase
    {
        #region Constructor

        public FCompanyGroups()
        {
            InitializeComponent();
        }

        #endregion

        #region Open Company Group

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            uCompanyGroups.Initialize();
        }

        private void uCompanyGroups_OpenCoGroup(object sender, OpenCoGroupEventArgs e)
        {
            if (e.IsCoGroupChanged)
                DialogResult = DialogResult.OK;
        
            Close();
        }

        #endregion
    }
}
