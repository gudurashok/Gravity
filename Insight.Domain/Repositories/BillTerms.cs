using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Insight.Domain.Repositories
{
    public class BillTerms : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<BillTermEntity>()
                     .Where(b => b.Description.StartsWith(criteria.SearchText))
                     .OrderBy(c => c.Description).ToList()
                     .Select(b => new BillTermListItem
                                    {
                                        BillTerm = new BillTerm(b)
                                                    {
                                                        Daybook = new Daybook(s.Load<DaybookEntity>(b.DaybookId))
                                                    }
                                    })
                     .Cast<dynamic>().ToList();
            }
        }
    }
}
