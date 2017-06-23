using System;
using Insight.Domain.Model;

namespace Insight.UC.Events
{
    public class ItemAddedEventArgs : EventArgs
    {
        public SaleInvoiceLine Item { get; private set; }

        public ItemAddedEventArgs(SaleInvoiceLine item)
        {
            Item = item;
        }
    }
}
