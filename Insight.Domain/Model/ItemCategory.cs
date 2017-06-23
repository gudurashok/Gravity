using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class ItemCategory
    {
        public ItemCategoryEntity Entity { get; set; }

        public ItemCategory(ItemCategoryEntity entity)
        {
            Entity = entity;
        }
    }
}
