using Insight.Domain.Repositories;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class ItemGroupList : PicklistBase
    {
        public ItemGroupList()
            : base("Name")
        {
        }

        protected override string getTitleText()
        {
            return "Select Item Group";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
        }

        protected override IListRepository createRepository()
        {
            return new ItemGroups();
        }
    }
}
