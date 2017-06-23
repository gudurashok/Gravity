using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using Synergy.Domain.Entities;

namespace Synergy.Domain.Indexes
{
    public class Tasks_Count : AbstractIndexCreationTask<TaskEntity, Tasks_Count.ReduceResult>, IIndexDefinition
    {
        public class ReduceResult
        {
            public string UserId { get; set; }
            public int Count { get; set; }
        }

        public Tasks_Count()
        {
            Map = tasks => from task in tasks
                           select new { UserId = task.CreatedById, Count = 1 };

            Reduce = results => from taskCount in results
                                group taskCount by taskCount.UserId into g
                                select new ReduceResult { UserId = g.Key, Count = g.Sum(x => x.Count) };

            Sort(result => result.Count, SortOptions.Int);
        }
    }
}
