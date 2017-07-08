using Foresight.Logic.Sql;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class CompanyTopCustomersDataContext : CompanyTopperBaseDataContext
    {
        protected override string getCompanyPeriodTotalValueQuery(string filterExpr)
        {
            return string.Format(ReportQueries.SelectTotalOfSale, 
                                filterExpr, getTypeCodes());
        }

        protected override string getAccountsQuery(string filterExpr)
        {
            return string.Format(ReportQueries.SelectTopNCustomers, TopNCount, 
                                getPartyIdentityColumn(), getTypeCodes(),
                                filterExpr);
        }

        private string getTypeCodes()
        {
            return GetChartOfAccountIds(AccountTypes.Customers);
        }
    }
}
