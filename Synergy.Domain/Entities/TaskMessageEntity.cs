using System;
using Gravity.Root.Common;
using Synergy.Domain.Enums;

namespace Synergy.Domain.Entities
{
    public class TaskMessageEntity
    {
        public string Id { get; set; }
        public string ToUserId { get; set; }
        public string TaskId { get; set; }
        //public string TaskNumber { get; set; }
        public string TaskName { get; set; }
        public string ByUserId { get; set; }
        public string ByUserName { get; set; }
        public TaskUpdateType Type { get; set; }
        public DateTime DateTime { get; set; }

        public static TaskMessageEntity New()
        {
            return new TaskMessageEntity { Id = EntityPrefix.MessagePrefix };
        }
    }
}
