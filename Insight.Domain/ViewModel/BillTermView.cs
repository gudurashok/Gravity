using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class BillTermView
    {
        public string Description { get; set; }
        public string Percentage { get; set; }
        public string Amount { get; set; }

        public BillTermView(SaleInvoiceTerm term)
        {
            Description = term.Entity.Description;
            Percentage = term.Entity.Percentage.ToString();
            Amount = term.Entity.Amount.ToString();
        }
    }
}
