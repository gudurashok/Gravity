using System.ComponentModel.DataAnnotations;
using Insight.Domain.Enums;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class DaybookEntity
    {
        public string Id { get; set; }
        public DaybookType Type { get; set; }
        public string Code { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "DaybookNameCannotBeEmpty")]
        public string Name { get; set; }
        public string AccountId { get; set; }
        public DocumentEntryType DocumentEntryType { get; set; }
    }
}
