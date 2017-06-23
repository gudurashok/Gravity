﻿using Gravity.Root.Events;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Mingle.Domain.Repositories;
using Scalable.Shared.Common;
using Synergy.Domain.Repositories;
using SynergyDefaultDataRepository = Synergy.Domain.Repositories.DefaultDataRepository;
using MingleDefaultDataRepository = Mingle.Domain.Repositories.DefaultDataRepository;
using InsightDefaultDataRepository = Insight.Domain.Repositories.DefaultDataRepository;

namespace Insight.UC.Forms
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
            new InsightDefaultDataRepository().InsertCompanyPeriod(coGroup);
            new SynergyDefaultDataRepository().Insert();
            new InsightDefaultDataRepository().Insert();

            if (AppConfig.CreateTestUsers)
                new TestUsersRepository().Insert();

            if (AppConfig.CreateTestParties)
                new TestPartiesRepository().Insert();

            if (AppConfig.CreateTestTasks)
                new TestTasksRepository().Insert();
        }

        //protected override Assembly[] GetAssembliesToScanForIndexingTasks()
        //{
        //    //return new Assembly[] { Assembly.GetAssembly(typeof(Party_AllParties)) };
        //}
    }
}
