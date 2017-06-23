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
    public class ItemGroups : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<ItemGroupEntity>()
                     .Where(i => i.Name.StartsWith(criteria.SearchText))
                     .OrderBy(i => i.Name)
                     .Select(i => new ItemGroup(i))
                     .ToList()
                     .Cast<dynamic>().ToList();
            }
        }
    }
}
