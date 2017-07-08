using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Synergy.Domain.Indexes;
using Synergy.UC.Forms;
using Synergy.Win.Forms;
using MingleSysConfig = Mingle.Domain.Model.SysConfig;

namespace Synergy.Win.Common
{
    public class SynergyApp : ReleaseGravityAppBase
    {
        protected override FCompanyGroupBase getCompanyGroupForm(CompanyGroup coGroup)
        {
            return new FCompanyGroup(coGroup);
        }

        protected override Form GetSplashScreen()
        {
            return new FSplash();
        }

        protected override void setMainForm()
        {
            MainForm = new FMain(this);
        }

        protected override void saveMainWindowStateInUserConfig()
        {
            if (SkipSaveUserConfig) return;

            var settings = new Dictionary<string, object>();
            var mainForm = ApplicationContext.MainForm;
            settings.Add(UserConfig.synergyMainWindowStateKey, mainForm.WindowState);
            settings.Add(UserConfig.synergyMainWindowStartPositionKey, MainForm.StartPosition);
            settings.Add(UserConfig.synergyMainWindowLocationKey, mainForm.Location);
            settings.Add(UserConfig.synergyMainWindowSizeKey, mainForm.Size);
            UserConfig.SaveSettings(GravitySession.User.Entity.Id, settings);
        }

        protected override void setUserConfig()
        {
            var winState = UserConfig.SynergyMainWindowState;
            MainForm.WindowState = winState == FormWindowState.Minimized
                                            ? FormWindowState.Normal
                                            : winState;

            MainForm.StartPosition = UserConfig.SynergyMainWindowLocation.IsEmpty
                                    ? UserConfig.SynergyMainWindowStartPosition
                                    : FormStartPosition.Manual;
            var size = UserConfig.SynergyMainWindowSize;
            MainForm.Size = size.IsEmpty ? MainForm.Size : size;

            var location = UserConfig.SynergyMainWindowLocation;
            if (!Screen.PrimaryScreen.WorkingArea.Contains(location.X, location.Y))
                MainForm.StartPosition = FormStartPosition.CenterScreen;
            else
                MainForm.Location = location.IsEmpty ? MainForm.Location : location;
        }

        //protected override void createIndexes()
        //{
        //    GravitySession.StoreManager.CreateIndexesFrom(GetAssembliesToScanForIndexingTasks());
        //}

        //protected virtual IEnumerable<Assembly> GetAssembliesToScanForIndexingTasks()
        //{
        //    return new[] { Assembly.GetAssembly(typeof(IIndexDefinition)) };
        //}

        //protected override void insertData()
        //{
        //    base.insertData();
        //    new MingleDefaultDataRepository(GravitySession.CompanyGroup).Insert();
        //    new SynergyDefaultDataRepository().Insert();

        //    if (AppConfig.CreateTestParties)
        //        new TestPartiesRepository().Insert();

        //    if (AppConfig.CreateTestTasks)
        //        new TestTasksRepository().Insert();
        //}
    }
}
