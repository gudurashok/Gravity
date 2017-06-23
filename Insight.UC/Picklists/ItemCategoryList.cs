using Insight.Domain.Repositories;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class ItemCategoryList : PicklistBase
    {
        public ItemCategoryList()
            : base("Name")
        {
        }

        protected override string getTitleText()
        {
            return "Select Item Category";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
        }

        protected override IListRepository createRepository()
        {
            return new ItemCategories();
        }
    }
}
