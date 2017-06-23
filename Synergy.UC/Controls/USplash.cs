using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Synergy.UC.Controls
{
    public partial class USplash : UserControl
    {
        public USplash()
        {
            InitializeComponent();
        }

        private void USplash_Load(object sender, EventArgs e)
        {
            var asm = Assembly.GetExecutingAssembly();
            var version = (AssemblyFileVersionAttribute)Attribute
                                .GetCustomAttribute(asm, typeof(AssemblyFileVersionAttribute));
            lblVersion.Text = string.Format("Version: {0}", version.Version);
        }

        private void lnkiScalableWeb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            launchLink();
        }

        private void launchLink()
        {
            Process.Start("http://www.gravitysoftware.in");
        }
    }
}
