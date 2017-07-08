using System.Windows.Forms;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Services;
using Scalable.Shared.Common;
using Scalable.Win.Common;
using System;
using System.Collections.Generic;

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

        protected virtual void saveMainWindowStateInUserConfig()
        {
            if (SkipSaveUserConfig) return;

            //var settings = new Dictionary<string, object>();
            //var mainForm = ApplicationContext.MainForm;
            //settings.Add(UserConfig.gravityMainWindowStateKey, mainForm.WindowState);
            //settings.Add(UserConfig.gravityMainWindowStartPositionKey, MainForm.StartPosition);
            //settings.Add(UserConfig.gravityMainWindowLocationKey, mainForm.Location);
            //settings.Add(UserConfig.gravityMainWindowSizeKey, mainForm.Size);
            //UserConfig.SaveSettings(GravitySession.User.Entity.Id, settings);
        }

        protected virtual void setUserConfig()
        {
            //var winState = UserConfig.GravityMainWindowState;
            //MainForm.WindowState = winState == FormWindowState.Minimized
            //                                ? FormWindowState.Normal
            //                                : winState;

            //MainForm.StartPosition = UserConfig.GravityMainWindowLocation.IsEmpty
            //                        ? UserConfig.GravityMainWindowStartPosition
            //                        : FormStartPosition.Manual;
            //var size = UserConfig.GravityMainWindowSize;
            //MainForm.Size = size.IsEmpty ? MainForm.Size : size;

            //var location = UserConfig.GravityMainWindowLocation;
            //if (!Screen.PrimaryScreen.WorkingArea.Contains(location.X, location.Y))
            //    MainForm.StartPosition = FormStartPosition.CenterScreen;
            //else
            //    MainForm.Location = location.IsEmpty ? MainForm.Location : location;
        }

        protected override void OnShutdown()
        {
            GravitySession.Dispose();
            base.OnShutdown();
        }
    }
}
