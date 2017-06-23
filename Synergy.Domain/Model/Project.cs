using Synergy.Domain.Entities;

namespace Synergy.Domain.Model
{
    public class Project
    {
        public ProjectEntity Entity { get; set; }

        public Project(ProjectEntity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return Entity.Name;
        }
    }
}
