using Foresight.Logic.Sql;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class CompanyTopExpensesDataContext : CompanyTopperBaseDataContext
    {
        protected override string getCompanyPeriodTotalValueQuery(string filterExpr)
        {
            var coaIds = ChartOfAccount.GetChartOfAccountIds((int)ChartOfAccountType.Expense);
            return string.Format(ReportQueries.SelectTotalOfExpense, filterExpr, coaIds);
        }

        protected override string getAccountsQuery(string filterExpr)
        {
            var coaIds = ChartOfAccount.GetChartOfAccountIds((int)ChartOfAccountType.Expense);
            return string.Format(ReportQueries.SelectTopNExpenses, TopNCount,
                            getPartyIdentityColumn(), filterExpr, coaIds);
        }
    }
}
