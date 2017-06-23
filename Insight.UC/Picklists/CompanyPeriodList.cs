using Insight.Domain.Repositories;
using Insight.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class CompanyPeriodList : PicklistBase
    {
        private readonly bool _onlySelection;
        private readonly bool _withNewEntry;

        public CompanyPeriodList(bool onlySelection = true, bool withNewEntry = false)
            : base("Company")
        {
            _onlySelection = onlySelection;
            _withNewEntry = withNewEntry;
        }

        protected override string getTitleText()
        {
            return "Select company period";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Company", true));
            lvw.Columns.Add(new iColumnHeader("Period", 90));
        }

        protected override UPicklist createControl()
        {
            if (_withNewEntry)
            {
                var picklist = new UCompanyPeriods();
                picklist.Initialize();
                return picklist;
            }

            return base.createControl(_onlySelection);
        }

        protected override IListRepository createRepository()
        {
            return new CompanyPeriods();
        }
    }
}
