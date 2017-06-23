using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Synergy.Domain.Enums;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class TaskEntity
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public string Tag { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "TaskNameCannotBeEmpty")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionText { get; set; }
        public string ParentId { get; set; }
        public double Value { get; set; }

        public string EstimatedTime { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? StartDate { get; set; }

        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string AssignedById { get; set; }
        public string AssignedToId { get; set; }
        public IList<string> CcToIds { get; set; }

        public Priority Priority { get; set; }
        public string TypeId { get; set; }
        public string ProjectId { get; set; }
        public string LocationId { get; set; }
        public ChecklistEntity Checklist { get; set; }
        public RecurrenceEntity Recurrence { get; set; }
        public IList<AttachmentEntity> Attachments { get; set; }

        public TaskStatus Status { get; set; }
        public int CompletePct { get; set; }
        public DateTime? CompletedOn { get; set; }

        public TaskEntity()
        {
            Id = EntityPrefix.TaskPrefix;        
            CreatedOn = DateTime.Now;
            Status = TaskStatus.Pending;
            Priority = Priority.Normal;
            Checklist = new ChecklistEntity();
            Attachments = new List<AttachmentEntity>();
            CcToIds = new List<string>();
        }
    }
}
