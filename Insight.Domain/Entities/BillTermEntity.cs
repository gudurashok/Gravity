using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class BillTermEntity
    {
        public string Id { get; set; }
        public int Type { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "BillTermCodeCannotBeEmpty")]
        public char Code { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "DescriptionCannotBeEmpty")]
        public string Description { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "DaybookNameCannotBeEmpty")]
        public string DaybookId { get; set; }
        public char Sign { get; set; }
        public string Formula { get; set; }
        public double Percentage { get; set; }
    }
}
