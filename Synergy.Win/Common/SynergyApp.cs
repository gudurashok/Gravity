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

        protected override FMainBase getMainForm()
        {
            return new FMain(this);
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
