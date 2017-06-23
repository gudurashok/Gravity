using Microsoft.VisualBasic.ApplicationServices;
using Gravity.Root.Forms;
using System.Windows.Forms;
using Scalable.Win.Common;

namespace Foresight.Win.Common
{
    public class ForesightApplication : ScalableApplicationBase
    {
        public const string ProductName = "Foresight";

        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            var loginForm = new FLogin();
            if (loginForm.ShowDialog() != DialogResult.OK)
                return false;

            var coGroupsForm = new FCompanyGroups();
            if (coGroupsForm.ShowDialog() != DialogResult.OK)
                return false;

            MainForm = new FMainBase(this);
            return true;
        }
    }
}
