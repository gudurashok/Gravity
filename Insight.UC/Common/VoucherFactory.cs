using System.ComponentModel.DataAnnotations;
using Insight.Domain.Enums;
using Insight.UC.Controls;
using Insight.UC.Forms;
using Insight.Domain.Entities;
using Insight.Domain.Model;

namespace Insight.UC.Common
{
    public static class VoucherFactory
    {
        public static UVoucher GetVoucherForm(Daybook daybook, FDaybooks daybooksForm, CashBankTransactionType transactionType = CashBankTransactionType.None)
        {
            var bookType = daybook.Entity.Type;

            if (transactionType == CashBankTransactionType.Receipt && bookType == DaybookType.Cash)
                return new UCashReceipt(daybooksForm);

            if (transactionType == CashBankTransactionType.Payment && bookType == DaybookType.Cash)
                return new UCashPayment(daybooksForm);

            if (transactionType == CashBankTransactionType.Receipt && bookType == DaybookType.Bank)
                return new UBankReceipt(daybooksForm);

            if (transactionType == CashBankTransactionType.Payment && bookType == DaybookType.Bank)
                return new UBankPayment(daybooksForm);

            if (bookType == DaybookType.JournalVoucher)
                return new UJournalVoucher(daybooksForm);

            if (bookType == DaybookType.CreditNote)
                return new UCreditNote(daybooksForm);

            if (bookType == DaybookType.DebitNote)
                return new UDebitNote(daybooksForm);

            if (bookType == DaybookType.Sale)
            {
                if (daybook.Entity.DocumentEntryType == DocumentEntryType.WithoutInventory)
                    return new USaleVoucher(daybooksForm);
                else
                    return new USaleInvoice(daybooksForm);
            }

            if (bookType == DaybookType.Purchase)
            {
                if (daybook.Entity.DocumentEntryType == DocumentEntryType.WithoutInventory)
                    return new UPurchaseVoucher(daybooksForm);
                else
                    throw new ValidationException("Under Construction"); //return new UPurchaseInvoice(daybooksForm);
            }

            throw new ValidationException("Under Construction");
        }
    }
}
