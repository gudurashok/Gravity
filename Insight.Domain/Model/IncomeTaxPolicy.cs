using System;

namespace Insight.Domain.Model
{
    public class IncomeTaxPolicy
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public string PermanentAccountNr { get; set; }
        public string TdsRegistrationNr { get; set; }
        public DateTime TdsRegistrationDate { get; set; }
    }
}
