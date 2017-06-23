using System.Collections.Generic;

namespace Insight.Domain.Entities
{
    public class PurchaseInvoiceEntity : TransactionHeaderEntity
    {
        public decimal BrokerageAmount { get; set; }
        public string Through { get; set; }
        public string Transport { get; set; }
        public string ReferenceDocNr { get; set; }
        public string OrderId { get; set; }
        public double DiscountPct { get; set; }
        public string SaleTaxColumnId { get; set; }

        public IList<PurchaseInvoiceLineEntity> LineEntities { get; set; }
        public IList<PurchaseInvoiceTermEntity> TermEntities { get; set; }

        public PurchaseInvoiceEntity()
        {
            LineEntities = new List<PurchaseInvoiceLineEntity>();
            TermEntities = new List<PurchaseInvoiceTermEntity>();
        }
    }
}
