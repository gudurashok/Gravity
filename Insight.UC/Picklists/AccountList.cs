using Insight.Domain.Repositories;
using Insight.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class AccountList : PicklistBase
    {
        private readonly bool _withNewEntry;
        private UAccounts _picklist;

        public AccountList(bool withNewEntry = false)
            : base("Name")
        {
            _withNewEntry = withNewEntry;
        }

        protected override string getTitleText()
        {
            return "Select account";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
            lvw.Columns.Add(new iColumnHeader("ChartOfAccount", 120));
        }

        protected override UPicklist createControl()
        {
            if (_withNewEntry)
            {
                if (_picklist != null)
                    return _picklist;

                _picklist = new UAccounts();
                _picklist.Initialize();
                return _picklist;
            }

            var picklist = new UAccountList();
            picklist.Initialize();
            picklist.btnOpen.Visible = false;
            return picklist;
        }

        protected override IListRepository createRepository()
        {
            return new Accounts();
        }
    }
}
