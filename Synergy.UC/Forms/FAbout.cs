using System.Windows.Forms;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Synergy.UC.Forms
{
    public partial class FAbout : Form
    {
        public FAbout()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            Text = string.Format("About {0}", CommonUtil.GetProdcutName());
            var uAbout = new Synergy.UC.Controls.UAbout();
            uAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            uAbout.BorderStyle = BorderStyle.None;
            uAbout.Location = new System.Drawing.Point(0, 0);
            uAbout.Size = new System.Drawing.Size(629, 396);
            this.Controls.Add(uAbout);
        }
    }
}
