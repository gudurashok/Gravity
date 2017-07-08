using Foresight.Logic.Sql;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class PeriodTopExpensesDataContext : PeriodTopperBaseDataContext
    {
        protected override string getCompanyPeriodTotalValueQuery(string filterExpr)
        {
            string coaIds = GetChartOfAccountIds((int)ChartOfAccountType.Expense);
            return string.Format(ReportQueries.SelectTotalOfExpense, filterExpr, coaIds);
        }

        protected override string getAccountsQuery(string filterExpr)
        {
            string coaIds = GetChartOfAccountIds((int)ChartOfAccountType.Expense);
            return string.Format(ReportQueries.SelectTopNExpenses, TopNCount,
                                getPartyIdentityColumn(), filterExpr, coaIds);
        }
    }
}
