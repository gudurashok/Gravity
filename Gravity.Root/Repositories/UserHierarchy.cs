using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Entities;
using Gravity.Root.Model;
using Gravity.Root.ViewModel;
using Raven.Client.Linq;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;

namespace Gravity.Root.Repositories
{
    class UserHierarchy : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<UserEntity>()
                        .Where(u => u.Name.StartsWith(criteria.SearchText))
                        .OrderBy(u => u.Name).ToList()
                        .Select(u => new UserHeirarchyListItem
                                    {
                                        User = new User(u)
                                        {
                                            Parent = string.IsNullOrWhiteSpace(u.ParentId)
                                                    ? null : new User(s.Load<UserEntity>(u.ParentId))
                                        }
                                    }
                                )
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
