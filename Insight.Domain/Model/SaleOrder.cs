using System.Collections.Generic;

namespace Insight.Domain.Model
{
    public class SaleOrder
    {
        public SaleOrderHeader Header { get; set; }
        public IList<SaleOrderLine> Lines { get; set; }
    }
}
