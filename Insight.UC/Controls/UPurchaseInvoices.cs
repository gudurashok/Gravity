using Insight.Domain.Entities;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Insight.UC.Forms;
using Scalable.Shared.Repositories;
using Scalable.Win.Events;

namespace Insight.UC.Controls
{
    public partial class UPurchaseInvoices : UVouchers
    {
        public UPurchaseInvoices()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            newVoucherToolStripMenuItem.Text = @"&New Purchase Invoice";
            base.Initialize();
        }

        protected override IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            return new PurchaseInvoices(criteria);
        }

        protected override void ProcessNewVoucher()
        {
            if (!IsDaybookSelected(DaybookType.Purchase))
                return;

            var invoice = new PurchaseInvoice(new PurchaseInvoiceEntity());
            invoice.Daybook = _selectedDaybook;
            showInvoiceForm(invoice);
        }

        private void showInvoiceForm(TransactionHeader invoice)
        {
            var purchaseInvoice = new FVoucher(invoice, _fDaybooks);
            purchaseInvoice.ShowDialog();
            FillList(true);
        }

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            var invoice = GetPurcaseInvoice(e);
            showInvoiceForm(invoice);
        }

        protected virtual TransactionHeader GetPurcaseInvoice(PicklistItemEventArgs e)
        {
            var trans = ((PurchaseInvoiceListItem)e.PicklistItem).TransactionHeader;
            var result = new PurchaseInvoice(trans.Entity as PurchaseInvoiceEntity);
            fillVoucherDetails(result, trans);
            return result;
        }
    }
}
