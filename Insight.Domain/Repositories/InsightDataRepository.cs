using System;
using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Mingle.Domain.Repositories;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class InsightDataRepository : RepositoryBase, IForesightDataMethods
    {
        public IList<AccountEntity> GetAllAccounts()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<AccountEntity>()
                        .OrderBy(c => c.Name)
                        .ToList();
            }
        }

        public IList<ChartOfAccountEntity> GetAllChatOfAccounts()
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<ChartOfAccountEntity>()
                        .OrderBy(c => c.Name)
                        .ToList();
            }
        }
    }
}
