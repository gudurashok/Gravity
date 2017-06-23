using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Raven.Client.Linq;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Synergy.Domain.Entities;

namespace Synergy.Domain.Repositories
{
    public class TaskTemplates : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<TaskTemplateEntity>()
                        .Where(t => t.Name.StartsWith(criteria.SearchText))
                        .OrderBy(t => t.Name).ToList()
                        .Select(t => TaskRepository.GetTaskTemplateWithFullDetails(t, s))
                        .Cast<dynamic>().ToList();
            }
        }
    }
}
