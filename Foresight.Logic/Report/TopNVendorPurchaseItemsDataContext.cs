using Foresight.Logic.Sql;
using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Foresight.Logic.Report
{
    public class TopNVendorPurchaseItemsDataContext : TopNAccountItemsBaseDataContext
    {
        private const string columnName = "Purchase";

        protected override string getTopNQuery()
        {
            return string.Format(ReportQueries.SelectTopNAccountItems,
                                TopNCount, getPartyIdentityColumn(), getItemIdentityColumn(), getTableName(),
                                columnName, ChartOfAccount.GetChartOfAccountIds(AccountTypes.Vendors));
        }
    }
}
