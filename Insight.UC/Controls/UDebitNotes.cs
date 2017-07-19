using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Repositories;
using Scalable.Win.Events;

namespace Insight.UC.Controls
{
    public partial class UDebitNotes : UVouchers
    {
        public UDebitNotes()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            newVoucherToolStripMenuItem.Text = @"&New Debit Note";
            base.Initialize();
        }

        protected override IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            return new DebitNotes(criteria);
        }

        protected override void ProcessNewVoucher()
        {
            if (!IsDaybookSelected(DaybookType.DebitNote))
                return;

            base.ProcessNewVoucher();
        }

        protected override TransactionHeader GetTransactionHeader(PicklistItemEventArgs e)
        {
            var trans = ((TransactionListItem)e.PicklistItem).TransactionHeader;
            var result = new DebitNote(trans.Entity as DebitNoteEntity);
            fillVoucherDetails(result, trans);
            return result;
        }
    }
}
