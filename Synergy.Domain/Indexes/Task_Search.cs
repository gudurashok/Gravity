using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using Synergy.Domain.Entities;

namespace Synergy.Domain.Indexes
{
    public class Task_Search : AbstractMultiMapIndexCreationTask<Task_Search.Result>, IIndexDefinition
    {
        public class Result
        {
            public string TaskId { get; set; }
            public object[] SearchQuery { get; set; }
        }

        public Task_Search()
        {
            AddMap<TaskEntity>(tasks => from task in tasks
                                        select new Result
                                        {
                                            TaskId = task.Id,
                                            SearchQuery = new[]
                                                        {
                                                            task.Name, 
                                                            task.Tag, 
                                                            task.DescriptionText
                                                        }
                                        });

            AddMap<TaskCommentEntity>(comments => from comment in comments
                                                  select new Result
                                                  {
                                                      TaskId = comment.TaskId,
                                                      SearchQuery = new[] { comment.Comment }
                                                  });

            Reduce = results => from result in results
                                group result by result.TaskId
                                    into g
                                    select new Result
                                    {
                                        TaskId = g.Key,
                                        SearchQuery = g.Where(t => t.TaskId == g.Key)
                                                        .Select(c => c.SearchQuery).ToArray()
                                    };

            Index(p => p.SearchQuery, FieldIndexing.Analyzed);
        }
    }
}
