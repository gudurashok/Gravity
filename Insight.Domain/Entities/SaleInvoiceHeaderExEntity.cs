namespace Insight.Domain.Entities
{
    public class SaleInvoiceHeaderExEntity
    {
        public string InvoiceId { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddressLine1 { get; set; }
        public string ShipToAddressLine2 { get; set; }
        public string ShipToCity { get; set; }
    }
}
