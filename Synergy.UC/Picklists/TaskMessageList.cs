using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Picklist;

namespace Synergy.UC.Picklists
{
    public class TaskMessageList : PicklistBase
    {
        public TaskMessageList()
            : base("TaskName")
        {
        }

        protected override string getTitleText()
        {
            return "Task message list";
        }

        protected override void createColumns(iListView lvw)
        {
            lvw.Columns.Add(new iColumnHeader("TaskNumber", "Task Nr.", 60));
            lvw.Columns.Add(new iColumnHeader("TaskName", "Task name", true));
            lvw.Columns.Add(new iColumnHeader("Type", "Update type", 60));
            lvw.Columns.Add(new iColumnHeader("ByUserName", "By user", 60));
            lvw.Columns.Add(new iColumnHeader("DateTime", "Date and Time", 60));
        }

        protected override IListRepository createRepository()
        {
            throw new System.NotImplementedException();
            //return new Tasks();
        }
    }
}
