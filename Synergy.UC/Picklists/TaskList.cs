using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;
using Scalable.Win.Picklist;
using Synergy.Domain.Model;
using Synergy.Domain.Repositories;
using Synergy.UC.Controls;

namespace Synergy.UC.Picklists
{
    public class TaskList : PicklistBase
    {
        public TaskList()
            : base("Name")
        {
        }

        protected override string getTitleText()
        {
            return "Select Task";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("Nr", "Number", 60));
            lvw.Columns.Add(new iColumnHeader("ParentTaskNr", "Parent", 60));
            lvw.Columns.Add(new iColumnHeader("Name", true));
            lvw.Columns.Add(new iColumnHeader("Tag", 60));
            lvw.Columns.Add(new iColumnHeader("Priority", 70));
            lvw.Columns.Add(new iColumnHeader("Attachments", "A", 25));
            lvw.Columns.Add(new iColumnHeader("Comments", "C", 25));
            lvw.Columns.Add(new iColumnHeader("Status", 180));
        }

        protected override UPicklist createControl()
        {
            var picklist = new UTasks();
            build(picklist);
            picklist.SearchProperty = _searchProperty;
            picklist.ReInitialize(true);
            return picklist;
        }

        protected override IListRepository createRepository()
        {
            return new Tasks(new TaskSearchCriteria());
        }
    }
}
