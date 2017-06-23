using Insight.Domain.Enums;
using Insight.Domain.Repositories;
using Insight.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class ChartOfAccountList : PicklistBase
    {
        private readonly bool _withNewEntry;
        private readonly ChartOfAccountType _type;
        private UChartOfAccounts _picklist;

        public ChartOfAccountList(bool withNewEntry = false,
                                    ChartOfAccountType type = ChartOfAccountType.None)
            : base("Name")
        {
            _type = type;
            _withNewEntry = withNewEntry;
        }

        protected override string getTitleText()
        {
            return "Select chart of account";
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
                if (_picklist != null)
                    return _picklist;

                _picklist = new UChartOfAccounts();
                _picklist.Initialize();
                return _picklist;
            }

            var picklist = new UChartOfAccountList();
            picklist.Initialize();
            picklist.btnOpen.Visible = false;
            return picklist;
        }

        protected override IListRepository createRepository()
        {
            return new ChartOfAccounts(_type);
        }
    }
}
