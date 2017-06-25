using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class CompanyEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "CompanyNameCannotBeEmpty")]
        public string Name { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "PartyCannotBeEmpty")]
        public string PartyId { get; set; }
    }
}
