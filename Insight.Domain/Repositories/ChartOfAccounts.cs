using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Raven.Client;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class ChartOfAccounts : RepositoryBase, IListRepository
    {
        private readonly ChartOfAccountType _type;

        public ChartOfAccounts(ChartOfAccountType type = ChartOfAccountType.None)
        {
            _type = type;
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return getChartOfAccounts(criteria, s)
                        .Select(c => new ChartOfAccountListItem
                        {
                            ChartOfAccount = new ChartOfAccount(c)
                            {
                                Parent = string.IsNullOrEmpty(c.ParentId)
                                            ? null
                                            : new ChartOfAccount(s.Load<ChartOfAccountEntity>(c.ParentId))
                            }
                        })
                        .Cast<dynamic>().ToList();
            }
        }

        private IEnumerable<ChartOfAccountEntity> getChartOfAccounts(PicklistSearchCriteria criteria, IDocumentSession s)
        {
            if (_type == ChartOfAccountType.None)
                return s.Query<ChartOfAccountEntity>()
                        .Where(c => c.Name.StartsWith(criteria.SearchText))
                        .OrderBy(c => c.Name).ToList();

            return s.Query<ChartOfAccountEntity>()
                    .Where(c => c.Name.StartsWith(criteria.SearchText))
                    .OrderBy(c => c.Name).ToList()
                    .Where(c => c.Type == _type).ToList();
        }
    }
}
