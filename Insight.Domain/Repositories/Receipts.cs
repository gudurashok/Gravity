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
    public class Receipts : Transactions
    {
        public Receipts(VoucherSearchCriteria voucherSearchCriteria)
            : base(voucherSearchCriteria)
        {
        }

        public override IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                IList<dynamic> bankReceipts = getBankReceiptsSearchQuery(s)
                                            .Where(v => v.CompanyPeriodId == InsightSession.CompanyPeriod.Entity.Id)
                                            .ToList()
                                            .Cast<dynamic>()
                                            .ToList();

                IList<dynamic> cashReceipts = getCashReceiptsSearchQuery(s)
                                            .Where(v => v.CompanyPeriodId == InsightSession.CompanyPeriod.Entity.Id)
                                            .ToList()
                                            .Cast<dynamic>()
                                            .ToList();

                return bankReceipts
                            .Concat(cashReceipts)
                            .Select(e =>
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


        private IQueryable<TransactionHeaderEntity> getBankReceiptsSearchQuery(IDocumentSession s)
        {
            IQueryable<TransactionHeaderEntity> query = s.Query<BankReceiptEntity>();

            query = SetDocumentNrFilter(query);
            query = SetDaybookFilter(query);
            query = SetAccountFilter(query);
            query = SetDateFilter(query);
            query = SetAmountFilter(query);

            return query;
        }

        private IQueryable<TransactionHeaderEntity> getCashReceiptsSearchQuery(IDocumentSession s)
        {
            IQueryable<TransactionHeaderEntity> query = s.Query<CashReceiptEntity>();

            query = SetDocumentNrFilter(query);
            query = SetDaybookFilter(query);
            query = SetAccountFilter(query);
            query = SetDateFilter(query);
            query = SetAmountFilter(query);

            return query;
        }
    }
}
