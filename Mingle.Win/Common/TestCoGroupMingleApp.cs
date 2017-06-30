using System.Collections.Generic;
using System.Reflection;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Mingle.Domain.Indexes;
using Mingle.Domain.Repositories;
using Mingle.Win.Forms;
using Scalable.Shared.Common;

namespace Mingle.Win.Common
{
    public class TestCoGroupMingleApp : TestCoGroupGravityAppBase
    {
        protected override void insertData()
        {
            base.insertData();
            new DefaultDataRepository(GravitySession.CompanyGroup).Insert();

            if (AppConfig.CreateTestParties)
                new TestPartiesRepository().Insert();

            //createIndexes();
        }

        //private void createIndexes()
        //{
        //    GravitySession.StoreManager.CreateIndexesFrom(GetAssembliesToScanForIndexingTasks());
        //}

        //protected virtual IEnumerable<Assembly> GetAssembliesToScanForIndexingTasks()
        //{
        //    return new[] { Assembly.GetAssembly(typeof(IIndexDefinition)) };
        //}

        protected override void setMainForm()
        {
            MainForm = new FMain(this);
        }
    }
}
