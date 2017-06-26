using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public abstract class InvoiceLineEntity
    {
        public string Id { get; set; }
        public string InvoiceId { get; set; }
        public int LineNr { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "ItemNameCannotBeEmpty")]
        public string ItemId { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity1 { get; set; }
        public double Packing { get; set; }
        public double Quantity2 { get; set; }
        public double Quantity3 { get; set; }
        public double DiscountPct { get; set; }
        public decimal Amount { get; set; }
    }
}
