using System;
using System.Windows.Forms;
using Synergy.UC.Controls;

namespace Synergy.UC.Forms
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
