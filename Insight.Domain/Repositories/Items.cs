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
    public class Items : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<ItemEntity>()
                     .Where(i => i.Name.StartsWith(criteria.SearchText))
                     .OrderBy(i => i.Name)
                     .ToList()
                     .Select(i => new ItemListItem
                                    {
                                        Item = new Item(i)
                                                {
                                                    Category = i.CategoryId == null ? null : new ItemCategory(s.Load<ItemCategoryEntity>(i.CategoryId)),
                                                    Group = i.GroupId == null ? null : new ItemGroup(s.Load<ItemGroupEntity>(i.GroupId))

                                                }
                                    })
                     .Cast<dynamic>().ToList();
            }
        }
    }
}
