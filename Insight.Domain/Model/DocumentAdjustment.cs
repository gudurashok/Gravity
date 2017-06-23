using System;

namespace Insight.Domain.Model
{
    public class DocumentAdjustment
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
        public string CrDocNr { get; set; }
        public string DbDocNr { get; set; }
        public decimal Amount { get; set; }
    }
}
