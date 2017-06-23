using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class SaleInvoiceHeaderEx
    {
        public SaleInvoiceHeaderExEntity Entity { get; set; }

        public SaleInvoiceHeaderEx(SaleInvoiceHeaderExEntity entity)
        {
            Entity = entity;
        }

        public static SaleInvoiceHeaderEx New()
        {
            return new SaleInvoiceHeaderEx(new SaleInvoiceHeaderExEntity());
        }
    }
}
