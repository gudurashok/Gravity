using Mingle.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;
using Mingle.Domain.Repositories;

namespace Mingle.UC.Picklists
{
    public class PartyList : PicklistBase
    {
        public PartyList()
            : base("Name")
        {
        }

        protected override string getTitleText()
        {
            return "Select party";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", 190));
            lvw.Columns.Add(new iColumnHeader("Contact", 190));
            lvw.Columns.Add(new iColumnHeader("Phone", 110));
            lvw.Columns.Add(new iColumnHeader("Location", true, 130));
        }

        protected override UPicklist createControl()
        {
            var picklist = new UParties();
            build(picklist);
            picklist.SearchProperty = _searchProperty;
            picklist.HidePreviewBar();
            picklist.HookEventHandlers();
            return picklist;
        }

        protected override IListRepository createRepository()
        {
            return new Parties();
        }
    }
}
