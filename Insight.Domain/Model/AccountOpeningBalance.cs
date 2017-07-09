using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class AccountOpeningBalance
    {
        public AccountOpeningBalanceEntity Entity { get; set; }
        public Account Account { get; set; }
    }
}
