using System.Collections.Generic;

namespace Insight.Domain.Entities
{
    public class SaleInvoiceEntity : TransactionHeaderEntity
    {
        public decimal BrokerageAmount { get; set; }
        public string Through { get; set; }
        public string VehicleId { get; set; }
        public string Transport { get; set; }
        public string ReferenceDocNr { get; set; }
        public string OrderId { get; set; }
        public double DiscountPct { get; set; }
        public string SaleTaxColumnId { get; set; }
        public string ShipToName { get; set; }
        public string ShipToAddressLine1 { get; set; }
        public string ShipToAddressLine2 { get; set; }
        public string ShipToCity { get; set; }

        public IList<SaleInvoiceLineEntity> LineEntities { get; set; }
        public IList<SaleInvoiceTermEntity> TermEntities { get; set; }

        public SaleInvoiceEntity()
        {
            LineEntities = new List<SaleInvoiceLineEntity>();
            TermEntities = new List<SaleInvoiceTermEntity>();
        }
    }
}
