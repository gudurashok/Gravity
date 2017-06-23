using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class ChecklistEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ChecklistNameCannotBeEmpty")]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<ChecklistItemEntity> Items { get; set; }
        public bool IsActive { get; set; }

        public ChecklistEntity()
        {
            Items = new List<ChecklistItemEntity>();
        }

        public static ChecklistEntity New()
        {
            return new ChecklistEntity { Id = EntityPrefix.ChecklistPrefix };
        }
    }
}
