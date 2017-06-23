using System;
using System.Windows.Forms;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Scalable.Win.Forms
{
    public partial class FSplash : Form
    {
        public FSplash()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var uSplash = new USplash();
            uSplash.Dock = DockStyle.Fill;
            Controls.Add(uSplash);
        }
    }
}
