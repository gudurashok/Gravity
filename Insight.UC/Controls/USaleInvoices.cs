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
    public partial class USaleInvoices : UVouchers
    {
        public USaleInvoices()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            newVoucherToolStripMenuItem.Text = @"&New Sale Invoice";
            base.Initialize();
        }

        protected override IListRepository GetRepository(VoucherSearchCriteria criteria)
        {
            return new SaleInvoices(criteria);
        }

        protected override void ProcessNewVoucher()
        {
            if (!IsDaybookSelected(DaybookType.Sale))
                return;

            var invoice = new SaleInvoice(new SaleInvoiceEntity());
            invoice.Daybook = _selectedDaybook;
            showInvoiceForm(invoice);
        }

        private void showInvoiceForm(TransactionHeader invoice)
        {
            var saleInvoice = new FVoucher(invoice, _fDaybooks);
            saleInvoice.ShowDialog();
            FillList(true);
        }

        protected override void OnItemOpened(PicklistItemEventArgs e)
        {
            var invoice = GetSaleInvoice(e);
            showInvoiceForm(invoice);
        }

        protected virtual TransactionHeader GetSaleInvoice(PicklistItemEventArgs e)
        {
            var trans = ((TransactionListItem)e.PicklistItem).TransactionHeader;
            var result = new SaleInvoice(trans.Entity as SaleInvoiceEntity);
            fillVoucherDetails(result, trans);
            return result;
        }
    }
}
