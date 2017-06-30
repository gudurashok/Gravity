using System.Collections.Generic;
using System.Reflection;
using Gravity.Root.Common;
using Gravity.Root.Forms;
using Synergy.Domain.Indexes;
using Mingle.Domain.Repositories;
using Scalable.Shared.Common;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.Win.Forms;
using MingleDefaultDataRepository = Mingle.Domain.Repositories.DefaultDataRepository;
using SynergyDefaultDataRepository = Synergy.Domain.Repositories.DefaultDataRepository;

namespace Synergy.Win.Common
{
    public class TestCoGroupSynergyApp : TestCoGroupGravityAppBase
    {
        protected override void insertData()
        {
            base.insertData();
            new MingleDefaultDataRepository(GravitySession.CompanyGroup).Insert();
            new SynergyDefaultDataRepository().Insert();

            if (AppConfig.CreateTestParties)
                new TestPartiesRepository().Insert();

            if (AppConfig.CreateTestTasks)
                new TestTasksRepository().Insert();

            createIndexes();
            //createDummyData();
        }

        private void createDummyData()
        {
            for (var i = 1; i < 1200; i++)
            {
                var task = Task.New();
                task.Entity.Name = "Dummy Task" + i;
                task.Entity.Tag = "Dummy";
                task.Entity.CreatedById = GravitySession.User.Entity.Id;
                task.Entity.Description = "Dummy Task Description" + i;
                task.Entity.DescriptionText = "Dummy Task Description" + i;
                task.Save(true);
            }
        }

        private void createIndexes()
        {
            GravitySession.StoreManager.CreateIndexesFrom(GetAssembliesToScanForIndexingTasks());
        }

        protected virtual IEnumerable<Assembly> GetAssembliesToScanForIndexingTasks()
        {
            return new[] { Assembly.GetAssembly(typeof(IIndexDefinition)) };
        }

        protected override void setMainForm()
        {
            MainForm = new FMain(this);
        }
    }
}
