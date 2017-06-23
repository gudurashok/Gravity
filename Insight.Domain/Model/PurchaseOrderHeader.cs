using System;

namespace Insight.Domain.Model
{
    public class PurchaseOrderHeader
    {
        public string Id { get; set; }
        public Daybook Daybook { get; set; }
        public string DocumentNr { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
        public Account Broker { get; set; }
        public string Through { get; set; }
        public string Transport { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}
