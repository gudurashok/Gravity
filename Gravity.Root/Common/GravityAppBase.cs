using System.Windows.Forms;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Services;
using Scalable.Shared.Common;
using Scalable.Win.Common;
using System;

namespace Gravity.Root.Common
{
    public abstract class GravityAppBase : ScalableApplicationBase
    {
        public bool SkipSaveUserConfig { get; set; }

        protected bool loginNotPerformed(bool isRootLogin = false)
        {
            if (AppConfig.CoGroupAutoLogin)
            {
                GravitySession.User = AuthenticationService.Authenticate(User.CreateAdminCredentials());
                return false;
            }

            var loginForm = new FLogin(this, isRootLogin);
            return (loginForm.ShowDialog() != DialogResult.OK);
        }

        protected virtual void setMainForm()
        {
            MainForm = new FMainBase(this);
        }

        protected void applicationContext_ThreadExit(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveMainWindowStateInUserConfig);
        }

        private void saveMainWindowStateInUserConfig()
        {
            if (SkipSaveUserConfig) return;

            var mainForm = ApplicationContext.MainForm;
            UserConfig.MainWindowState = mainForm.WindowState;
            UserConfig.MainWindowStartPosition = MainForm.StartPosition;
            UserConfig.MainWindowLocation = mainForm.Location;
            UserConfig.MainWindowSize = mainForm.Size;
        }

        protected void setUserConfig()
        {
            var winState = UserConfig.MainWindowState;
            MainForm.WindowState = winState == FormWindowState.Minimized
                                            ? FormWindowState.Normal
                                            : winState;

            MainForm.StartPosition = UserConfig.MainWindowLocation.IsEmpty
                                    ? UserConfig.MainWindowStartPosition
                                    : FormStartPosition.Manual;
            var size = UserConfig.MainWindowSize;
            MainForm.Size = size.IsEmpty ? MainForm.Size : size;

            var location = UserConfig.MainWindowLocation;
            if (!Screen.PrimaryScreen.WorkingArea.Contains(location.X, location.Y))
                MainForm.StartPosition = FormStartPosition.CenterScreen;
            else
                MainForm.Location = location.IsEmpty ? MainForm.Location : location;
        }

        protected override void OnShutdown()
        {
            GravitySession.Dispose();
            base.OnShutdown();
        }
    }
}
