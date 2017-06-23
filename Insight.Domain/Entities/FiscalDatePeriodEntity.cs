using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;
using Scalable.Shared.Model;

namespace Insight.Domain.Entities
{
    public class FiscalDatePeriodEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "FiscalDatePeriodNameCannotBeEmpty")]
        public string Name { get; set; }
        public DatePeriod Financial { get; set; }
        public DatePeriod Assessment { get; set; }
    }
}
