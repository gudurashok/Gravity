using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class SaleInvoiceTerm : InvoiceTerm
    {
        public SaleInvoiceTerm(SaleInvoiceTermEntity entity)
        {
            Entity = entity;
        }

        public static SaleInvoiceTerm New()
        {
            return new SaleInvoiceTerm(new SaleInvoiceTermEntity());
        }
    }
}
