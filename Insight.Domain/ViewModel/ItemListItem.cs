using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class ItemListItem
    {
        public Item Item{ get; set; }

        public string Name
        {
            get { return Item.Entity.Name; }
        }

        public string Group
        {
            get { return Item.Group.Entity.Name; }
        }

        public string Category
        {
            get { return Item.Category.Entity.Name; }
        }
    }
}
