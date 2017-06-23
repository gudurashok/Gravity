using System;
using Insight.Domain.Model;

namespace Insight.UC.Events
{
    public class VoucherSearchEventArgs : EventArgs
    {
        public VoucherSearchCriteria Criteria { get; private set; }

        public VoucherSearchEventArgs(VoucherSearchCriteria criteria)
        {
            Criteria = criteria;
        }
    }
}
