using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Mingle.Domain.Repositories;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Raven.Client;
using System;
using Gravity.Root.Common;
using Insight.Domain.Common;

namespace Insight.Domain.Repositories
{
    public class Accounts : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            var repo = new PartyRepository();
            using (var s = Store.OpenSession())
            {
                return s.Query<AccountEntity>()
                        .Where(c => c.Name.StartsWith(criteria.SearchText))
                        .OrderBy(c => c.Name)
                        .ToList()
                        .Select(a => new AccountListItem
                        {
                            Account = new Account(a)
                            {
                                Group = string.IsNullOrEmpty(a.GroupId)
                                            ? null
                                            : new Account(s.Load<AccountEntity>(a.GroupId)),
                                Party = string.IsNullOrEmpty(a.PartyId)
                                            ? null
                                            : repo.GetById(a.PartyId, false),
                                ChartOfAccount = new ChartOfAccount(s.Load<ChartOfAccountEntity>(a.ChartOfAccountId)),
                                OpeningBalance = getOpeningBalance(a.Id, s),
                            }
                        })
                        .Cast<dynamic>().ToList();
            }
        }

        private AccountOpeningBalanceEntity getOpeningBalance(string accountId, IDocumentSession s)
        {
            var companyPeriodId = InsightSession.CompanyPeriod.Entity.Id;
            var result = s.Query<AccountOpeningBalanceEntity>()
                          .Where(aob => aob.AccountId == accountId)
                          .Where(aob => aob.CompanyPeriodId == companyPeriodId)
                          .SingleOrDefault();

            if (result != null)
                return result;

            return new AccountOpeningBalanceEntity { AccountId = accountId };
        }
    }
}
