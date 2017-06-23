using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.UC.Forms;

namespace Insight.UC.Controls
{
    public partial class UCashPayment : UVoucher
    {
        public UCashPayment(FDaybooks fDaybooks)
            : base(fDaybooks)
        {
            InitializeComponent();
        }

        protected override void ProcessNew()
        {
            DataSource = new CashPayment(
                new CashPaymentEntity()) { Daybook = Voucher.Daybook };
        }
    }
}
