using System;
using System.ComponentModel.DataAnnotations;
using Synergy.Domain.Enums;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class AttachmentEntity
    {
        public int Nr { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AttachmentNameCannotBeEmpty")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AttachmentPathCannotBeEmpty")]
        public string Path { get; set; }
        public AttachmentType Type { get; set; }
        public DateTime AttachedOn { get; set; }
    }
}
