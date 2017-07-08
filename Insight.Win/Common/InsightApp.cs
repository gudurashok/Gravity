using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Insight.UC.Forms;
using Insight.Win.Forms;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Insight.Win.Common
{
    public class InsightApp : ReleaseGravityAppBase
    {
        protected override FCompanyGroupBase getCompanyGroupForm(CompanyGroup coGroup)
        {
            return new FCompanyGroup(coGroup);
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
            settings.Add(UserConfig.insightMainWindowStateKey, mainForm.WindowState);
            settings.Add(UserConfig.insightMainWindowStartPositionKey, MainForm.StartPosition);
            settings.Add(UserConfig.insightMainWindowLocationKey, mainForm.Location);
            settings.Add(UserConfig.insightMainWindowSizeKey, mainForm.Size);
            UserConfig.SaveSettings(GravitySession.User.Entity.Id, settings);
        }

        protected override void setUserConfig()
        {
            var winState = UserConfig.InsightMainWindowState;
            MainForm.WindowState = winState == FormWindowState.Minimized
                                            ? FormWindowState.Normal
                                            : winState;

            MainForm.StartPosition = UserConfig.InsightMainWindowLocation.IsEmpty
                                    ? UserConfig.InsightMainWindowStartPosition
                                    : FormStartPosition.Manual;
            var size = UserConfig.InsightMainWindowSize;
            MainForm.Size = size.IsEmpty ? MainForm.Size : size;

            var location = UserConfig.InsightMainWindowLocation;
            if (!Screen.PrimaryScreen.WorkingArea.Contains(location.X, location.Y))
                MainForm.StartPosition = FormStartPosition.CenterScreen;
            else
                MainForm.Location = location.IsEmpty ? MainForm.Location : location;
        }

        //protected override void insertData()
        //{
        //    base.insertData();
        //    new MingleDefaultDataRepository(GravitySession.CompanyGroup).Insert();
        //    new SynergyDefaultDataRepository().Insert();
        //    new InsightDefaultDataRepository().Insert();

        //    if (AppConfig.CreateTestParties)
        //        new TestPartiesRepository().Insert();

        //    if (AppConfig.CreateTestTasks)
        //        new TestTasksRepository().Insert();

        //    if (AppConfig.CreateTestInsightData)
        //        new TestInsightRepository().Insert();
        //}
    }
}
