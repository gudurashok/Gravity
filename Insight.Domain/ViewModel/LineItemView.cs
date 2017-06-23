using Insight.Domain.Entities;
using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class LineItemView
    {
        public string Item { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Amount { get; set; }

        public LineItemView(SaleInvoiceLine line)
        {
            Item = line.Item.Entity.ShortName;
            Quantity = line.Entity.Quantity1.ToString();
            Price = ((SaleInvoiceLineEntity)line.Entity).Price.ToString();
            Amount = line.Entity.Amount.ToString();
        }
    }
}
