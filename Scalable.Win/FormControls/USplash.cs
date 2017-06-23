using System;
using System.Reflection;
using System.Windows.Forms;

namespace Scalable.Win.FormControls
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
    }
}
