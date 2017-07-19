using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.UC.Events;
using Insight.UC.Forms;

namespace Insight.UC.Controls
{
    public partial class UCashReceipt : UVoucher
    {
        public UCashReceipt(FDaybooks fDaybooks)
            : base(fDaybooks)
        {
            InitializeComponent();
        }

        protected override void ProcessNew()
        {
            var oldDate = dtpDate.Value;
            DataSource = new CashReceipt(new CashReceiptEntity { Date = oldDate })
            {
                Daybook = Voucher.Daybook
            };
        }

        protected override void ProcessSave(object sender)
        {
            ((CashReceipt)DataSource).Save();
            OnTransactionSaved(new VoucherSavedEventArgs(Voucher.Entity, CommandBar[sender]));
        }
    }
}
