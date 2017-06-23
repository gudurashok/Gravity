namespace Insight.Domain.Model
{
    public class AccountMonthlyLedger
    {
        public string Id { private get; set; }
        public string DaybookId { get; set; }
        public string AccountId { get; set; }
        public string ChartOfAccountId { get; set; }
        public int Month { get; set; }
        public decimal Opening { get; private set; }
        public decimal Sale { get; private set; }
        public decimal CashPayment { get; private set; }
        public decimal BankPayment { get; private set; }
        public decimal DebitNote { get; private set; }
        public decimal DebitJV { get; private set; }
        public decimal Purchase { get; private set; }
        public decimal CashReceipt { get; private set; }
        public decimal BankReceipt { get; private set; }
        public decimal CreditNote { get; private set; }
        public decimal CreditJV { get; private set; }
        public CompanyPeriod CompanyPeriod { get; set; }
    }
}
