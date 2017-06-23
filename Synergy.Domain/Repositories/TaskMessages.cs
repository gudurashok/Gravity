using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Common;
using Gravity.Root.Repositories;
using Raven.Client.Linq;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Synergy.Domain.Entities;
using Synergy.Domain.ViewModel;

namespace Synergy.Domain.Repositories
{
    public class TaskMessages : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<TaskMessageEntity>()
                        .Where(m => m.ToUserId == GravitySession.User.Entity.Id)
                        .OrderByDescending(m => m.DateTime)
                        .ToList().Select(m => new MessageListItem { Entity = m })
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
