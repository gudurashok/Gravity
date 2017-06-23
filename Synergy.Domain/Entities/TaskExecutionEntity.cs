using System.Collections.Generic;

namespace Synergy.Domain.Entities
{
    public class TaskExecutionEntity
    {
        public string Id { get; set; }
        public IList<ExecutionEntity> Executions { get; set; }

        public TaskExecutionEntity(string id)
        {
            Id = id;
            Executions = new List<ExecutionEntity>();
        }
    }
}
