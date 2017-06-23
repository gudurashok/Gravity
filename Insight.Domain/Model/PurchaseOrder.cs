using System.Collections.Generic;

namespace Insight.Domain.Model
{
    public class PurchaseOrder
    {
        public PurchaseOrderHeader Header { get; set; }
        public IList<PurchaseOrderLine> Lines { get; set; }
    }
}
