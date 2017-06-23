using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Scalable.Shared.Repositories;

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
            TransactionType = TransactionType.Payment;
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
    }
}
