namespace Insight.Domain.Entities
{
    public class PurchaseInvoiceHeaderEntity : TransactionHeaderEntity
    {
        public decimal BrokerageAmount { get; set; }
        public string Through { get; set; }
        public string Transport { get; set; }
        public string ReferenceDocNr { get; set; }
        public string OrderId { get; set; }
        public double DiscountPct { get; set; }
        public string SaleTaxColumnId { get; set; }
    }
}
