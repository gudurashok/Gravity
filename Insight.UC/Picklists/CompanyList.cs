using Insight.Domain.Repositories;
using Insight.UC.Controls;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;

namespace Insight.UC.Picklists
{
    public class CompanyList : PicklistBase
    {
        private readonly bool _withNewEntry;

        public CompanyList(bool withNewEntry = false)
            : base("Name")
        {
            _withNewEntry = withNewEntry;
        }

        protected override string getTitleText()
        {
            return "Select company";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Name", true));
            lvw.Columns.Add(new iColumnHeader("Party", 100));
        }

        protected override UPicklist createControl()
        {
            if (_withNewEntry)
            {
                var picklist = new UCompanies();
                picklist.Initialize();
                return picklist;
            }

            var companypicklist = new UCompanyList();
            companypicklist.Initialize();
            companypicklist.btnOpen.Visible = false;
            return companypicklist;
        }

        protected override IListRepository createRepository()
        {
            return new Companies();
        }
    }
}
