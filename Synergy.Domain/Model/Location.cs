using Synergy.Domain.Entities;

namespace Synergy.Domain.Model
{
    public class Location
    {
        public LocationEntity Entity { get; set; }

        public Location(LocationEntity entity)
        {
            Entity = entity;
        }

        public override string ToString()
        {
            return Entity.Name;
        }
    }
}
