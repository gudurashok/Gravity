﻿using System.Linq;
using Ferry.Logic.MCS;
using Ferry.Logic.Sql;
using Foresight.Logic.DataAccess;
using Insight.Domain.Model;

namespace Ferry.Logic.TCS
{
    internal class TcsDataExtractor : McsDataExtractor
    {
        #region Constructor

        public TcsDataExtractor(Database sourceDatabase, DataContext targetDbContext)
            : base(sourceDatabase, targetDbContext)
        {
        }

        #endregion

        #region Internal Methods

        protected override string GetSelectAllGeneralLedgerGroupsQuery()
        {
            return TcsSqlQueries.SelectAllGeneralLedgerGroups;
        }

        internal override ChartOfAccount loadChartOfAccount(string glgCode)
        {
            var coaId = ChartOfAccountsMapper
                            .Where(c => c.TcsCode == glgCode || (glgCode.Length > 1 && c.TcsCode == glgCode.Substring(0, 1).Trim()))
                            .Select(c => c.ChartOfAccountId)
                            .SingleOrDefault();
            var coa = ChartOfAccounts
                            .Where(c => c.Entity.Id == coaId ||
                                c.Entity.Name == getDummyName(glgCode))
                            .SingleOrDefault();
            if (coa != null)
                return coa;

            return createChartOfAccount(glgCode);
        }

        #endregion
    }
}
