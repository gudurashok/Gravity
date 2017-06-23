using Ferry.Logic.MCS;
using Insight.Domain.Model;

namespace Ferry.Logic.TCS
{
    public class TcsDataImportContext : McsDataImportContext
    {
        public TcsDataImportContext(CompanyPeriod companyPeriod)
            : base(companyPeriod)
        {
        }

        protected override string getChartOfAccountsGroupFileName()
        {
            return "RPGRP.DBF";
        }
    }
}
