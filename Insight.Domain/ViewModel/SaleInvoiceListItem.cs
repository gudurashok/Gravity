using Insight.Domain.Model;

namespace Insight.Domain.ViewModel
{
    public class SaleInvoiceListItem
    {
        public TransactionHeader TransactionHeader { get; set; }

        public string DocumentNr
        {
            get { return TransactionHeader.Entity.DocumentNr; }
        }

        public string Daybook
        {
            get { return TransactionHeader.Daybook.ToString(); }
        }

        public string Date
        {
            get { return TransactionHeader.Entity.Date.ToShortDateString(); }
        }

        public string Account
        {
            get { return TransactionHeader.Account.Entity.Name; }
        }

        public string Amount
        {
            get { return TransactionHeader.Entity.Amount.ToString(); }
        }
    }
}
