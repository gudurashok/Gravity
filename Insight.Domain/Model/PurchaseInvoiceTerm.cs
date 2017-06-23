using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class PurchaseInvoiceTerm : InvoiceTerm
    {
        public PurchaseInvoiceTerm(PurchaseInvoiceTermEntity entity)
        {
            Entity = entity;
        }

        public static PurchaseInvoiceTerm New()
        {
            return new PurchaseInvoiceTerm(new PurchaseInvoiceTermEntity());
        }
    }
}
