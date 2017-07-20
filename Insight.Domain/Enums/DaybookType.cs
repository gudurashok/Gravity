using System;

namespace Insight.Domain.Enums
{
    public enum DocumentEntryType
    {
        WithoutInventory = 0,
        WithInventory = 1
    }

    [Flags]
    public enum DaybookType
    {
        Unknown = 0,
        Sale = 1,
        SaleReturn = 2,
        Purchase = 4,
        PurchaseReturn = 8,
        Cash = 16,
        Bank = 32,
        CreditNote = 64,
        DebitNote = 128,
        JournalVoucher = 256,
        InventoryIssue = 512,
        MiscInventoryIssue = 1024
    }
}
