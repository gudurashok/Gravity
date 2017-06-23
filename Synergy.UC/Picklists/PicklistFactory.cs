using Scalable.Win.Picklist;

namespace Synergy.UC.Picklists
{
    public static class PicklistFactory
    {
        private static TaskList taskList;

        public static IPicklist Tasks
        {
            get { return taskList ?? (taskList = new TaskList()); }
        }

        public static void ClearPicklistCache()
        {
            taskList = null;
        }
    }
}
