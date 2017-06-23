using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Insight.UC.Forms;
using Insight.Win.Forms;

namespace Insight.Win.Common
{
    public class InsightApp : ReleaseGravityAppBase
    {
        protected override FCompanyGroupBase getCompanyGroupForm(CompanyGroup coGroup)
        {
            return new FCompanyGroup(coGroup);
        }

        protected override FMainBase getMainForm()
        {
            return new FMain(this);
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
