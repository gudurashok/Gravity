using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Repositories;
using Scalable.Win.Events;

namespace Insight.UC.Controls
{
    public partial class UCreditNotes : UVouchers
    {
        public UCreditNotes()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            newVoucherToolStripMenuItem.Text = @"&New Credit Note";
            base.Initialize();
        }

        protected override IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            return new CreditNotes(criteria);
        }

        protected override void ProcessNewVoucher()
        {
            if (!IsDaybookSelected(DaybookType.CreditNote))
                return;

            base.ProcessNewVoucher();
        }

        protected override TransactionHeader GetTransactionHeader(PicklistItemEventArgs e)
        {
            var trans = ((TransactionListItem)e.PicklistItem).TransactionHeader;
            var result = new CreditNote(trans.Entity as CreditNoteEntity);
            fillVoucherDetails(result, trans);
            return result;
        }
    }
}
