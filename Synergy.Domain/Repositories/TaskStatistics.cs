using System.Collections.Generic;
using Gravity.Root.Repositories;
using System.Linq;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Synergy.Domain.Model;
using Synergy.Domain.ViewModel;

namespace Synergy.Domain.Repositories
{
    public class TaskStatistics : RepositoryBase, IListRepository
    {
        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            var repo = new TaskRepository();
            return repo.GetAllTaskStats()
                        .OrderBy(e => e.UserName)
                        .Select(e => new TaskStatsListItem
                                     {
                                         TaskStats = e,
                                         CurrentTask = TaskExecution.GetCurrentTask(e.UserId)
                                     })
                        .Cast<dynamic>().ToList();
        }
    }
}
