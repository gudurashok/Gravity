using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.UC.Events;
using Insight.UC.Forms;

namespace Insight.UC.Controls
{
    public partial class UPurchaseVoucher : UVoucher
    {
        public UPurchaseVoucher(FDaybooks fDaybooks)
            : base(fDaybooks)
        {
            InitializeComponent();
        }

        protected override void ProcessNew()
        {
            var oldDate = dtpDate.Value;
            DataSource = new PurchaseInvoice(new PurchaseInvoiceEntity { Date = oldDate })
            {
                Daybook = Voucher.Daybook
            };
        }

        protected override void ProcessSave(object sender)
        {
            ((PurchaseInvoice)DataSource).Save();
            OnTransactionSaved(new VoucherSavedEventArgs(Voucher.Entity, CommandBar[sender]));
        }
    }
}
