using System.ComponentModel.DataAnnotations;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class LocationEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "LocationNameCannotBeEmpty")]
        public string Name { get; set; }
        public string PartyId { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }
    }
}
