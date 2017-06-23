using System;
using Insight.Domain.Entities;
using Scalable.Win.Enums;

namespace Insight.UC.Events
{
    public class VoucherSavedEventArgs : EventArgs
    {
        public TransactionHeaderEntity Transaction { get; private set; }
        public CommandBarActionWrapper Action { get; set; }

        public VoucherSavedEventArgs(TransactionHeaderEntity transaction, 
                                            CommandBarActionWrapper action)
        {
            Transaction = transaction;
            Action = action;
        }
    }
}
