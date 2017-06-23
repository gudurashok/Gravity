using Insight.Domain.Repositories;
using Insight.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class ItemList : PicklistBase
    {
        private readonly bool _withNewEntry;
        private UItems _picklist;

        public ItemList(bool withNewEntry = false)
            : base("Name")
        {
            _withNewEntry = withNewEntry;
        }

        protected override string getTitleText()
        {
            return "Select item";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
        }

        protected override UPicklist createControl()
        {
            if (_withNewEntry)
            {
                if (_picklist != null)
                    return _picklist;

                _picklist = new UItems();
                _picklist.Initialize();
                return _picklist;
            }

            var picklist = new UItemList();
            picklist.Initialize();
            picklist.btnOpen.Visible = false;
            return picklist;
        }

        protected override IListRepository createRepository()
        {
            return new Items();
        }
    }
}
