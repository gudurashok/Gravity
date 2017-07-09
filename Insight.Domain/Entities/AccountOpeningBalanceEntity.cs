using System;

namespace Insight.Domain.Entities
{
    public class AccountOpeningBalanceEntity
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
