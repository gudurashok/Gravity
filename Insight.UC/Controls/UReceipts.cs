using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Scalable.Shared.Repositories;

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
            TransactionType = TransactionType.Receipt;
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
    }
}
