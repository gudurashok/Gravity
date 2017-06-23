using System.Reflection;
using Gravity.Root.Events;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Mingle.Domain.Indexes;
using Mingle.Domain.Repositories;
using Scalable.Shared.Common;
using MingleDefaultDataRepository = Mingle.Domain.Repositories.DefaultDataRepository;

namespace Mingle.UC.Forms
{
    public class FCompanyGroup : FCompanyGroupBase
    {
        public FCompanyGroup(CompanyGroup coGroup)
            : base(coGroup)
        {
            uCompanyGroup.CoGroupSaved += uCompanyGroup_CoGroupSaved;
        }

        void uCompanyGroup_CoGroupSaved(object sender, CoGroupSavedEventArgs e)
        {
            insertDefaultData(e.CompanyGroup);
        }

        private static void insertDefaultData(CompanyGroup coGroup)
        {
            new MingleDefaultDataRepository(coGroup).Insert();

            if (AppConfig.CreateTestUsers)
                new TestUsersRepository().Insert();

            if (AppConfig.CreateTestParties)
                new TestPartiesRepository().Insert();
        }

        protected override Assembly[] GetAssembliesToScanForIndexingTasks()
        {
            return new[] { Assembly.GetAssembly(typeof(IIndexDefinition)) };
        }
    }
}
