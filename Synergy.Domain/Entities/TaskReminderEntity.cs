using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class TaskReminderEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserIdCannotBeBlank")]
        public IList<string> UserIds { get; set; }
        public string TaskId { get; set; }
        //public int TaskNr { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ReminderNameCannotBeEmpty")]
        public string Name { get; set; }
        public DateTime RemindOn { get; set; }
        public bool IsDefault { get; set; }

        public TaskReminderEntity()
        {
            UserIds = new List<string>();
        }

        public static TaskReminderEntity New()
        {
            return new TaskReminderEntity { Id = EntityPrefix.ReminderPrefix };
        }
    }
}
