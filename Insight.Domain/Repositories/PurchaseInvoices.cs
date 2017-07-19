using System.Linq;
using System.Collections.Generic;
using Insight.Domain.Common;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Scalable.Shared.Model;

namespace Insight.Domain.Repositories
{
    public class PurchaseInvoices : Transactions
    {
        public PurchaseInvoices(VoucherSearchCriteria voucherSearchCriteria)
            : base(voucherSearchCriteria)
        {
        }

        public override IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<PurchaseInvoiceEntity>()
                        .Where(v => v.CompanyPeriodId == InsightSession.CompanyPeriod.Entity.Id).ToList()
                        .Select(e => new PurchaseInvoiceListItem { TransactionHeader = InsightRepository.GetPurchaseInvoiceWithFullDetails(e, s) })
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
