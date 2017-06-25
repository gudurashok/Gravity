using System.ComponentModel.DataAnnotations;
using Insight.Domain.Enums;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class ChartOfAccountEntity
    {
        public string Id { get; set; }
        public int Nr { get; set; }
        public string ParentId { get; set; }
        public ChartOfAccountType Type { get; set; }
        public string Sorting { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "ChartOfAccountNameCannotBeEmpty")]
        public string Name { get; set; }

        public ChartOfAccountEntity()
        {
            Type = ChartOfAccountType.Liability;
        }
    }
}
