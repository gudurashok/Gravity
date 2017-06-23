using System.Linq;
using System.Collections.Generic;
using Insight.Domain.Common;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Scalable.Shared.Model;

namespace Insight.Domain.Repositories
{
    public class SaleInvoices : Transactions
    {
        public SaleInvoices(VoucherSearchCriteria voucherSearchCriteria)
            : base(voucherSearchCriteria)
        {
        }

        public override IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<SaleInvoiceEntity>()
                        .Where(v => v.CompanyPeriodId == InsightSession.CompanyPeriod.Entity.Id).ToList()
                        .Select(e => new SaleInvoiceListItem { TransactionHeader = InsightRepository.GetInvoiceWithFullDetails(e, s) })
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
