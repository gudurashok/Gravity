using Gravity.Root.Common;
using Gravity.Root.Forms;
using Insight.Domain.Repositories;
using Insight.Win.Forms;
using Mingle.Domain.Repositories;
using Scalable.Shared.Common;
using Synergy.Domain.Repositories;
using MingleDefaultDataRepository = Mingle.Domain.Repositories.DefaultDataRepository;
using SynergyDefaultDataRepository = Synergy.Domain.Repositories.DefaultDataRepository;
using InsightDefaultDataRepository = Insight.Domain.Repositories.DefaultDataRepository;

namespace Insight.Win.Common
{
    public class TestCoGroupInsightApp : TestCoGroupGravityAppBase
    {
        protected override void insertData()
        {
            base.insertData();
            new MingleDefaultDataRepository(GravitySession.CompanyGroup).Insert();
            new InsightDefaultDataRepository().InsertCompanyPeriod(GravitySession.CompanyGroup);
            new SynergyDefaultDataRepository().Insert();
            new InsightDefaultDataRepository().Insert();

            if (AppConfig.CreateTestParties)
                new TestPartiesRepository().Insert();

            if (AppConfig.CreateTestTasks)
                new TestTasksRepository().Insert();

            if (AppConfig.CreateTestInsightData)
                new TestInsightRepository().Insert();
        }

        protected override FMainBase getMainForm()
        {
            return new FMain(this);
        }
    }
}
