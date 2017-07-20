using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Repositories;
using Scalable.Win.Events;

namespace Insight.UC.Controls
{
    public partial class UReceipts : UVouchers
    {
        public UReceipts()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            TransactionType = CashBankTransactionType.Receipt;
            newVoucherToolStripMenuItem.Text = @"&New Receipt";
            base.Initialize();
        }

        protected override IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            return new Receipts(criteria);
        }

        protected override void ProcessNewVoucher()
        {
            if (!IsDaybookSelected(DaybookType.Cash | DaybookType.Bank))
                return;

            base.ProcessNewVoucher();
        }

        protected override TransactionHeader GetTransactionHeader(PicklistItemEventArgs e)
        {
            var trans = ((TransactionListItem)e.PicklistItem).TransactionHeader;

            if (trans.Daybook.Entity.Type == DaybookType.Cash)
            {
                var cashReceipt = new CashReceipt(trans.Entity as CashReceiptEntity);
                fillVoucherDetails(cashReceipt, trans);
                return cashReceipt;
            }

            var bankReceipt = new BankReceipt(trans.Entity as BankReceiptEntity);
            fillVoucherDetails(bankReceipt, trans);
            return bankReceipt;
        }
    }
}
