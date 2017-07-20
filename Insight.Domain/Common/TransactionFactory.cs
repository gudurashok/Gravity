using Insight.Domain.Enums;
using Insight.Domain.Model;
using System;

namespace Insight.Domain.Common
{
    public static class TransactionFactory
    {
        public static TransactionHeader GetTransactionHeader(CashBankTransactionType transactionType, DaybookType daybookType)
        {
            if (daybookType == DaybookType.Cash && transactionType == CashBankTransactionType.Receipt)
                return CashReceipt.New();

            if (daybookType == DaybookType.Cash && transactionType == CashBankTransactionType.Payment)
                return CashPayment.New();

            if (daybookType == DaybookType.Bank && transactionType == CashBankTransactionType.Receipt)
                return BankReceipt.New();

            if (daybookType == DaybookType.Bank && transactionType == CashBankTransactionType.Payment)
                return BankPayment.New();

            if (daybookType == DaybookType.JournalVoucher)
                return JournalVoucher.New();

            if (daybookType == DaybookType.CreditNote)
                return CreditNote.New();

            if (daybookType == DaybookType.DebitNote)
                return DebitNote.New();

            throw new NotImplementedException($"Document of type: {daybookType} not implemented.");
        }
    }
}
