using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public abstract class InvoiceTerm
    {
        public BillTerm Term { get; set; }
        public Account Account { get; set; }
        public InvoiceTermEntity Entity { get; set; }
    }
}
