using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class PurchaseInvoiceLine : InvoiceLine
    {
        public PurchaseInvoiceLine(PurchaseInvoiceLineEntity entity)
        {
            Entity = entity;
        }

        public static PurchaseInvoiceLine New()
        {
            return new PurchaseInvoiceLine(new PurchaseInvoiceLineEntity());
        }
    }
}
