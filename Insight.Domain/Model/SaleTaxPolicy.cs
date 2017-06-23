using System;

namespace Insight.Domain.Model
{
    public class SaleTaxPolicy
    {
        public string Id { get; set; }
        public Account Account { get; set; }
        public string RegistrationNr { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
