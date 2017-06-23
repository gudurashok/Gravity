using Synergy.Domain.Entities;
using Synergy.Domain.Model;

namespace Synergy.Domain.ViewModel
{
    public class MessageListItem
    {
        public TaskMessageEntity Entity { get; set; }

        public string TaskNumber
        {
            get { return Entity.TaskId == null ? "" : Task.GetTaskNumber(Entity.TaskId); }
        }

        public string TaskName
        {
            get { return Entity.TaskName; }
        }

        public string Type
        {
            get { return Entity.Type.ToString(); }
        }

        public string ByUserName
        {
            get { return Entity.ByUserName; }
        }

        public string DateTime
        {
            get { return Entity.DateTime.ToString("dd-MMM-yyyy"); }
        }
    }
}
