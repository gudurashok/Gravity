using System.Linq;
using System.Collections.Generic;
using Insight.Domain.Common;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Raven.Client;
using Scalable.Shared.Model;

namespace Insight.Domain.Repositories
{
    public class JournalVouchers : Transactions
    {
        public JournalVouchers(VoucherSearchCriteria voucherSearchCriteria)
            : base(voucherSearchCriteria)
        {
        }

        public override IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return getJournalVouchersSearchQuery(s)
                        .Where(v => v.CompanyPeriodId == InsightSession.CompanyPeriod.Entity.Id).ToList()
                        .Select(e => new JournalVoucherListItem 
                                { TransactionHeader = InsightRepository.GetJVWithFullDetails(e as JournalVoucherEntity, s) })
                        .Cast<dynamic>().ToList();
            }
        }

        private IQueryable<TransactionHeaderEntity> getJournalVouchersSearchQuery(IDocumentSession s)
        {
            IQueryable<TransactionHeaderEntity> query = s.Query<JournalVoucherEntity>();

            query = SetDocumentNrFilter(query);
            query = SetDaybookFilter(query);
            query = SetAccountFilter(query);
            query = SetDateFilter(query);
            query = SetAmountFilter(query);
            return query;
        }
    }
}
