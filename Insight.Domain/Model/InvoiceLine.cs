using System.ComponentModel.DataAnnotations;
using Insight.Domain.Entities;
using Insight.Domain.Properties;

namespace Insight.Domain.Model
{
    public class InvoiceLine 
    {
        public Item Item { get; set; }
        public InvoiceLineEntity Entity { get; set; }

        public void Validate()
        {
            if (Item == null)
                throw new ValidationException(Resources.ItemCannotBeEmpty);

            if (Entity.Quantity1 == 0)
                throw new ValidationException(Resources.QuantityCannotBeZero);
        }
    }
}
