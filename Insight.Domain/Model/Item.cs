using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;
using Insight.Domain.Repositories;

namespace Insight.Domain.Model
{
    public class Item
    {
        public ItemEntity Entity { get; set; }
        public ItemGroup Group { get; set; }
        public ItemCategory Category { get; set; }

        public Item(ItemEntity entity)
        {
            Entity = entity;
        }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Entity.Id);
        }

        public void Save()
        {
            validateItem();

            var repo = new InsightRepository();
            repo.Save(Entity);
        }

        private void validateItem()
        {
            //TODO: Need to be uncommented when Item group and Category entities are stored
            //if (string.IsNullOrWhiteSpace(Entity.GroupId))
            //    throw new ValidationException(string.Format(Resources.ItemGroupNameCannotBeEmpty));

            //if (string.IsNullOrWhiteSpace(Entity.CategoryId))
            //    throw new ValidationException(string.Format(Resources.ItemCategoryNameConnotBeEmpty));

            if (string.IsNullOrWhiteSpace(Entity.Name))
                throw new ValidationException(string.Format(Resources.ItemNameCannotBeEmpty));
        }

        public static Item New()
        {
            return new Item(new ItemEntity());
        }
    }
}
