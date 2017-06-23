using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Synergy.UC.Controls
{
    public partial class UAbout : UserControl
    {
        public UAbout()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            initializeForm();
        }

        private void initializeForm()
        {
            var asm = Assembly.GetExecutingAssembly();
            lblCopyright.Text = getCopyright(asm);
            lblVersion.Text = string.Format("Version: {0}", getAssemblyVersion(asm));
        }

        private static string getCopyright(Assembly asm)
        {
            var copyrightAttr = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm,
                            typeof(AssemblyCopyrightAttribute));

            return copyrightAttr.Copyright;
        }

        private static string getAssemblyVersion(Assembly asm)
        {
            var versionAttr = (AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(asm,
                            typeof(AssemblyFileVersionAttribute));

            return versionAttr.Version;
        }

        private void UAbout_MouseClick(object sender, MouseEventArgs e)
        {
            ParentForm.Close();
        }

        private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            launchLink();
        }

        private void launchLink()
        {
            Process.Start("http://www.gravitysoftware.in");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
                launchLink();

            ParentForm.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
