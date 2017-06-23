using System.ComponentModel.DataAnnotations;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class ChecklistItemEntity
    {
        public int Nr { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ChecklistItemNameCannotBeEmpty")]
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }
}
