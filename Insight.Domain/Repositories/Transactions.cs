using System.Linq;
using System.Collections.Generic;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class Transactions : RepositoryBase, IListRepository
    {
        private readonly VoucherSearchCriteria _criteria;

        protected Transactions(VoucherSearchCriteria voucherSearchCriteria)
        {
            _criteria = voucherSearchCriteria;
        }

        public virtual IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            return null;
        }

        protected IQueryable<TransactionHeaderEntity> SetDocumentNrFilter(IQueryable<TransactionHeaderEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(_criteria.DocumentNr))
                query = query.Where(t => t.DocumentNr == _criteria.DocumentNr);

            return query;
        }

        protected IQueryable<TransactionHeaderEntity> SetDaybookFilter(IQueryable<TransactionHeaderEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(_criteria.DaybookId))
                query = query.Where(t => t.DaybookId == _criteria.DaybookId);

            return query;
        }

        protected IQueryable<TransactionHeaderEntity> SetAccountFilter(IQueryable<TransactionHeaderEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(_criteria.AccountId))
                query = query.Where(t => t.AccountId == _criteria.AccountId);

            return query;
        }

        protected IQueryable<TransactionHeaderEntity> SetDateFilter(IQueryable<TransactionHeaderEntity> query)
        {
            if (_criteria.Period != null)
                query = query.Where(t => t.Date >= _criteria.Period.From &&
                                        t.Date <= _criteria.Period.To);

            return query;
        }

        protected IQueryable<TransactionHeaderEntity> SetAmountFilter(IQueryable<TransactionHeaderEntity> query)
        {
            query = setMinimumAmountFilter(query);
            query = setMaximumAmountFilter(query);

            return query;
        }

        private IQueryable<TransactionHeaderEntity> setMinimumAmountFilter(IQueryable<TransactionHeaderEntity> query)
        {
            if (_criteria.MinAmount != 0)
                query = query.Where(t => t.Amount >= _criteria.MinAmount);

            return query;
        }

        private IQueryable<TransactionHeaderEntity> setMaximumAmountFilter(IQueryable<TransactionHeaderEntity> query)
        {
            if (_criteria.MaxAmount != 0)
                query = query.Where(t => t.Amount <= _criteria.MaxAmount);

            return query;
        }
    }
}
