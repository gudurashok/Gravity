using Foresight.Logic.Sql;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class TopNCutomerSaleItemsDataContext : TopNAccountItemsBaseDataContext
    {
        private const string columnName = "Sale";

        protected override string getTopNQuery()
        {
            return string.Format(ReportQueries.SelectTopNAccountItems,
                                TopNCount, getPartyIdentityColumn(), getItemIdentityColumn(), getTableName(), 
                                columnName, GetChartOfAccountIds(AccountTypes.Customers));
        }
    }
}
