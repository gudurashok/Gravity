using Insight.Domain.Enums;
using Insight.Domain.Repositories;
using Insight.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class DaybookList : PicklistBase
    {
        private readonly bool _onlySelection;
        private readonly bool _withNewEntry;
        private readonly DaybookType _type;

        public DaybookList(bool onlySelection = true, bool withNewEntry = false, 
                                    DaybookType type = DaybookType.Unknown)
            : base("Name")
        {
            _onlySelection = onlySelection;
            _withNewEntry = withNewEntry;
            _type = type;
        }

        protected override string getTitleText()
        {
            return "Select daybook";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
            lvw.Columns.Add(new iColumnHeader("Type", 90));
        }

        protected override UPicklist createControl()
        {
            if (_withNewEntry)
            {
                var picklist = new UDaybooks();
                picklist.Initialize();
                return picklist;
            }

            return base.createControl(_onlySelection);
        }

        protected override IListRepository createRepository()
        {
            return new Daybooks(_type);
        }
    }
}
