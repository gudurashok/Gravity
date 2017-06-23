using Insight.Domain.Repositories;
using Insight.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class FiscalDatePeriodList : PicklistBase
    {
        private readonly bool _withNewEntry;

        public FiscalDatePeriodList(bool withNewEntry = false)
            : base("Name")
        {
            _withNewEntry = withNewEntry;
        }

        protected override string getTitleText()
        {
            return "Select fiscal date period";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
            lvw.Columns.Add(new iColumnHeader("FinancialYear", true));
            lvw.Columns.Add(new iColumnHeader("AssessmentYear", true));
        }

        protected override UPicklist createControl()
        {
            if (_withNewEntry)
            {
                var picklist = new UFiscalDatePeriods();
                picklist.Initialize();
                return picklist;
            }

            var fiscalDatePeriodPicklist = new UFiscalDatePeriodList();
            fiscalDatePeriodPicklist.Initialize();
            fiscalDatePeriodPicklist.btnOpen.Visible = false;
            return fiscalDatePeriodPicklist;
        }

        protected override IListRepository createRepository()
        {
            return new FiscalDatePeriods();
        }
    }
}
