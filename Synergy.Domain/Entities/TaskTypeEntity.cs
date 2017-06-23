using System.ComponentModel.DataAnnotations;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class TaskTypeEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "TaskTypeNameCannotBeEmpty")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }
    }
}
