using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Repositories;
using Scalable.Win.Controls;
using Scalable.Win.Events;

namespace Insight.UC.Controls
{
    public partial class UJournalVouchers : UVouchers
    {
        public UJournalVouchers()
        {
            InitializeComponent();
            SearchProperty = "Daybook";
        }

        public override void Initialize()
        {
            newVoucherToolStripMenuItem.Text = @"&New Journal Voucher";
            base.Initialize();
        }

        protected override void BuildColumns()
        {
            ListView.Columns.Clear();

            ListView.Columns.Add(new iColumnHeader("DocumentNr", "Doc. Nr", 60));
            ListView.Columns.Add(new iColumnHeader("Daybook", 100));
            ListView.Columns.Add(new iColumnHeader("Date", 70));
            ListView.Columns.Add(new iColumnHeader("CreditAccount", "Cr.Account", true));
            ListView.Columns.Add(new iColumnHeader("DebitAccount", "Db.Account", true));
            ListView.Columns.Add(new iColumnHeader("Amount", 90));
        }

        protected override IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            return new JournalVouchers(criteria);
        }

        protected override void ProcessNewVoucher()
        {
            if (!IsDaybookSelected(DaybookType.JournalVoucher))
                return;

            base.ProcessNewVoucher();
        }

        protected override TransactionHeader GetTransactionHeader(PicklistItemEventArgs e)
        {
            return ((JournalVoucherListItem)e.PicklistItem).TransactionHeader;
        }
    }
}
