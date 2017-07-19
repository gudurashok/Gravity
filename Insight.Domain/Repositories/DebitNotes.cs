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
    public class DebitNotes : Transactions
    {
        public DebitNotes(VoucherSearchCriteria voucherSearchCriteria)
            : base(voucherSearchCriteria)
        {
        }

        public override IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                IList<dynamic> result = getSearchQuery(s)
                                    .Where(v => v.CompanyPeriodId == InsightSession.CompanyPeriod.Entity.Id)
                                    .ToList()
                                    .Cast<dynamic>()
                                    .ToList();

                return result.Select(e =>
                                new TransactionListItem
                                {
                                    TransactionHeader =
                                        InsightRepository
                                            .GetTransHeaderWithFullDetails(
                                                    new TransactionHeader { Entity = e }, s)
                                })
                            .Cast<dynamic>().ToList();
            }
        }

        private IQueryable<TransactionHeaderEntity> getSearchQuery(IDocumentSession s)
        {
            IQueryable<TransactionHeaderEntity> query = s.Query<DebitNoteEntity>();

            query = SetDocumentNrFilter(query);
            query = SetDaybookFilter(query);
            query = SetAccountFilter(query);
            query = SetDateFilter(query);
            query = SetAmountFilter(query);

            return query;
        }
    }
}
