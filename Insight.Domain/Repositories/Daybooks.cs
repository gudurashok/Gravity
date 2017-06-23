using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Raven.Client;
using Raven.Client.Linq;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class Daybooks : RepositoryBase, IListRepository
    {
        private readonly DaybookType _type;

        public Daybooks(DaybookType type = DaybookType.Unknown)
        {
            _type = type;
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return getDaybooks(criteria, s)
                            .Select(d => new DaybookListItem
                            {
                                Daybook = new Daybook(d)
                                {
                                    Account = string.IsNullOrWhiteSpace(d.AccountId)
                                                ? null
                                                : new Account(s.Load<AccountEntity>(d.AccountId))
                                }
                            })
                            .Cast<dynamic>().ToList();
            }
        }

        private IEnumerable<DaybookEntity> getDaybooks(PicklistSearchCriteria criteria, IDocumentSession s)
        {
            if (_type == DaybookType.Unknown)
                return s.Query<DaybookEntity>()
                        .Where(c => c.Name.StartsWith(criteria.SearchText))
                        .OrderBy(c => c.Name).ToList();

            return s.Query<DaybookEntity>()
                    .Where(c => c.Name.StartsWith(criteria.SearchText))
                    .OrderBy(c => c.Name).ToList()
                    .Where(d => (d.Type & _type) == d.Type).ToList();
        }
    }
}
