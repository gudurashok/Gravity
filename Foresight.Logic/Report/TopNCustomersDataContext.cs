using Foresight.Logic.Sql;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class TopNCustomersDataContext : TopNAccountsBaseDataContext
    {
        private const string queryPrefix = " AND CompanyPeriodId IN ";

        protected override string getTotalValueQuery()
        {
            return string.Format(ReportQueries.SelectTotalOfSale,
                    createFilterExprFrom(queryPrefix, getCoPeriodIds()), getTypeCodes());
        }

        protected override string getTopNQuery()
        {
            return string.Format(ReportQueries.SelectTopNCustomers,
                                TopNCount, getPartyIdentityColumn(), getTypeCodes(),
                                createFilterExprFrom(queryPrefix, getCoPeriodIds()));
        }

        private string getTypeCodes()
        {
            return GetChartOfAccountIds(AccountTypes.Customers);
        }
    }
}
