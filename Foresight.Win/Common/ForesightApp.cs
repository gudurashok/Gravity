using Foresight.Logic.DataAccess;
using Foresight.Win.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Microsoft.VisualBasic.ApplicationServices;
using Scalable.Shared.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Foresight.Win.Common
{
    public class ForesightApp : ReleaseGravityAppBase
    {
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            if (!base.OnStartup(eventArgs))
                return false;

            try
            {
                var coGroupDbExists = isForesightCompanyGroupExists();
                if (coGroupDbExists)
                    return true;

                var message = $"Company group \n'{GravitySession.CompanyGroup.Entity.Name}' not found.\n" +
                              $"Check it's physical file: {GravitySession.CompanyGroup.ForesightDatabaseName} exists.";
                MessageBoxUtil.ShowMessage(message);
            }
            catch (Exception ex)
            {
                MessageBoxUtil.ShowError(ex);
            }

            return false;
        }

        private bool isForesightCompanyGroupExists()
        {
            var db = ForesightDatabaseFactory.GetInstance();
            if (db.IsCompanyGroupNameExist(GravitySession.CompanyGroup.Entity.Name))
                return (db.IsCompanyGroupExist(GravitySession.CompanyGroup.Entity.ForesightDatabaseName));

            return false;
        }

        protected override void setMainForm()
        {
            MainForm = new FMain();
        }

        protected override void saveMainWindowStateInUserConfig()
        {
            if (SkipSaveUserConfig) return;

            var settings = new Dictionary<string, object>();
            var mainForm = ApplicationContext.MainForm;
            settings.Add(UserConfig.foresightMainWindowStateKey, mainForm.WindowState);
            settings.Add(UserConfig.foresightMainWindowStartPositionKey, MainForm.StartPosition);
            settings.Add(UserConfig.foresightMainWindowLocationKey, mainForm.Location);
            settings.Add(UserConfig.foresightMainWindowSizeKey, mainForm.Size);
            UserConfig.SaveSettings(GravitySession.User.Entity.Id, settings);
        }

        protected override void setUserConfig()
        {
            var winState = UserConfig.ForesightMainWindowState;
            MainForm.WindowState = winState == FormWindowState.Minimized
                                            ? FormWindowState.Normal
                                            : winState;

            MainForm.StartPosition = UserConfig.ForesightMainWindowLocation.IsEmpty
                                    ? UserConfig.ForesightMainWindowStartPosition
                                    : FormStartPosition.Manual;
            var size = UserConfig.ForesightMainWindowSize;
            MainForm.Size = size.IsEmpty ? MainForm.Size : size;

            var location = UserConfig.ForesightMainWindowLocation;
            if (!Screen.PrimaryScreen.WorkingArea.Contains(location.X, location.Y))
                MainForm.StartPosition = FormStartPosition.CenterScreen;
            else
                MainForm.Location = location.IsEmpty ? MainForm.Location : location;
        }
    }
}
