using System.Windows.Forms;
using Scalable.Shared.Common;

namespace Scalable.Win.Forms
{
    public partial class FAbout : Form
    {
        #region Constructor

        public FAbout()
        {
            InitializeComponent();
        }

        #endregion

        #region On form load

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            Text = string.Format("About {0}", CommonUtil.GetProdcutName());
        }

        #endregion
    }
}
