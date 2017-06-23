using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class AccountEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string GroupId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ChartOfAccountNameCannotBeEmpty")]
        public string ChartOfAccountId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AccountNameCannotBeEmpty")]
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pin { get; set; }
        public string PartyId { get; set; }
        public bool IsActive { get; set; }
    }
}
