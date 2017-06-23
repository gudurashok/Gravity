using Insight.Domain.Enums;
using Insight.Domain.Model;

namespace Insight.Domain.Common
{
    public static class TransactionFactory
    {
        public static TransactionHeader GetTransactionHeader(TransactionType transactionType, DaybookType daybookType)
        {
            if (daybookType == DaybookType.Cash && transactionType == TransactionType.Receipt)
                return CashReceipt.New();

            if (daybookType == DaybookType.Cash && transactionType == TransactionType.Payment)
                return CashPayment.New();

            if (daybookType == DaybookType.Bank && transactionType == TransactionType.Receipt)
                return BankReceipt.New();

            if (daybookType == DaybookType.Bank && transactionType == TransactionType.Payment)
                return BankPayment.New();

            if (daybookType == DaybookType.JournalVoucher)
                return JournalVoucher.New();

            return null;
        }
    }
}
