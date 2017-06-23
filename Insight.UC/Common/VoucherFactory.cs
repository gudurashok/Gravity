using System.ComponentModel.DataAnnotations;
using Insight.Domain.Enums;
using Insight.UC.Controls;
using Insight.UC.Forms;

namespace Insight.UC.Common
{
    public static class VoucherFactory
    {
        public static UVoucher GetVoucherForm(DaybookType bookType, FDaybooks fDaybooks, TransactionType transactionType = TransactionType.None)
        {
            if (transactionType == TransactionType.Receipt && bookType == DaybookType.Cash)
                return new UCashReceipt(fDaybooks);

            if (transactionType == TransactionType.Payment && bookType == DaybookType.Cash)
                return new UCashPayment(fDaybooks);

            if (transactionType == TransactionType.Receipt && bookType == DaybookType.Bank)
                return new UBankReceipt(fDaybooks);

            if (transactionType == TransactionType.Payment && bookType == DaybookType.Bank)
                return new UBankPayment(fDaybooks);

            if (bookType == DaybookType.JournalVoucher)
                return new UJournalVoucher(fDaybooks);

            if (bookType == DaybookType.Sale)
                return new USaleInvoice(fDaybooks);

            throw new ValidationException("Under Construction");
        }
    }
}
