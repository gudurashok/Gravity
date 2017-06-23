using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class SaleInvoiceLine : InvoiceLine
    {
        public SaleInvoiceLine(SaleInvoiceLineEntity entity)
        {
            Entity = entity;
        }

        public static SaleInvoiceLine New()
        {
            return new SaleInvoiceLine(new SaleInvoiceLineEntity());
        }
    }
}
