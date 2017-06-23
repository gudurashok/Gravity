using System;

namespace Insight.Domain.Model
{
    public class AccountOpeningBalance
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
