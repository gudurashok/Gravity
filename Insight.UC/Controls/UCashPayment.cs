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
            var oldDate = dtpDate.Value;
            DataSource = new CashPayment(new CashPaymentEntity { Date = oldDate })
            {
                Daybook = Voucher.Daybook
            };
        }
    }
}
