using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class ItemGroup
    {
        public ItemGroupEntity  Entity{ get; set; }

        public ItemGroup(ItemGroupEntity entity)
        {
            Entity = entity;
        }
    }
}
