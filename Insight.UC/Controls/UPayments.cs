using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Repositories;
using Scalable.Win.Events;

namespace Insight.UC.Controls
{
    public partial class UPayments : UVouchers
    {
        public UPayments()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            TransactionType = CashBankTransactionType.Payment;
            newVoucherToolStripMenuItem.Text = @"&New Payment"; 
            base.Initialize();
        }

        protected override IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            return new Payments(criteria);
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
                var cashPayment = new CashPayment(trans.Entity as CashPaymentEntity);
                fillVoucherDetails(cashPayment, trans);
                return cashPayment;
            }

            var bankPayment = new BankPayment(trans.Entity as BankPaymentEntity);
            fillVoucherDetails(bankPayment, trans);
            return bankPayment;
        }
    }
}
