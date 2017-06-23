using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Synergy.Domain.Enums;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class TaskTemplateEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "TemplateNameCannotBeEmpty")]
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }

        public string EstimatedTime { get; set; }
        public string AssignedById { get; set; }
        public string AssignedToId { get; set; }
        public IList<string> CcToIds { get; set; }

        public Priority Priority { get; set; }
        
        public string TypeId { get; set; }
        public string ProjectId { get; set; }
        public string LocationId { get; set; }
        
        public ChecklistEntity Checklist { get; set; }
        public IList<AttachmentEntity> Attachments { get; set; }

        public TaskTemplateEntity()
        {
            Checklist = new ChecklistEntity();
            Attachments = new List<AttachmentEntity>();
        }
    }
}
