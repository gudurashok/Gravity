using Insight.Domain.Enums;

namespace Insight.Domain.Model
{
    public class BankAccount
    {
        public string Id { get; set; }
        public string ContactId { get; set; } //TODO: Contact from Mingle
        public string AccountNr { get; set; } //Account Nr assigned by bank
        public BankAccountType TypeOfAccount { get; set; } 
        public Account Account { get; set; }
    }
}
