using Synergy.Domain.Entities;

namespace Synergy.Domain.Model
{
    public class TaskType
    {
        public TaskTypeEntity Entity { get; set; }

        public TaskType(TaskTypeEntity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return Entity.Name;
        }
    }
}
