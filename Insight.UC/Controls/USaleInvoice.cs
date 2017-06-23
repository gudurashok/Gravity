using System;
using System.Collections.Generic;
using System.Linq;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Events;
using Insight.UC.Forms;
using Scalable.Shared.Common;

namespace Insight.UC.Controls
{
    public partial class USaleInvoice : UVoucher
    {
        #region Declarations

        private SaleInvoice _saleInvoice;
        private IList<BillTerm> _billTerms;

        #endregion

        #region Constructor

        public USaleInvoice(FDaybooks fDaybooks)
            : base(fDaybooks)
        {
            InitializeComponent();
        }

        #endregion

        #region Initialize line item control

        public override void Initialize()
        {
            uLineItem.Initialize();
            uLineItem.ItemAdded += uLineItem_ItemAdded;
            base.Initialize();
        }

        #endregion

        #region Datasource

        public override object DataSource
        {
            get
            {
                FillObject();
                return _saleInvoice;
            }
            set
            {
                _saleInvoice = value as SaleInvoice;
                FillForm();
            }
        }

        protected override void FillObject()
        {
            _saleInvoice.Entity.DaybookId = ((Daybook)txtDaybook.Tag).Entity.Id;
            _saleInvoice.Entity.Date = dtpDate.Value;
            fillAccount();
            _saleInvoice.Entity.Amount = Convert.ToDecimal(ntbAmount.Text);
            _saleInvoice.Entity.Notes = rtbDescription.Text;
        }

        private void fillAccount()
        {
            _saleInvoice.Entity.AccountId = txbAccount.Value == null
                                                ? null
                                                : ((AccountListItem)txbAccount.Value).Account.Entity.Id;
        }

        protected override void FillForm()
        {
            setBillTerms();

            txtDaybook.Tag = _saleInvoice.Daybook;
            txtDaybook.Text = _saleInvoice.Daybook.Entity.Name;
            txtDocNr.Text = _saleInvoice.Entity.DocumentNr;
            dtpDate.Value = getDate();
            txbAccount.Value = setAccount();
            ntbAmount.Text = _saleInvoice.Entity.Amount.ToString();
            ntbAmount.Value = Convert.ToDouble(_saleInvoice.Entity.Amount);
            rtbDescription.Text = _saleInvoice.Entity.Notes;
            ntbAmount.Select();
            txbAccount.Select();

            fillItemList();
            fillBillTerms();
        }

        private void setBillTerms()
        {
            //TODO: IsNew is Public due to this. Try to move the below to model class and make protected again

            if (_saleInvoice.IsNew())
            {
                _billTerms = _saleInvoice.Daybook.GetBillTerms();
                _saleInvoice.SetBillTerms(_billTerms);
            }
            else
            {
                _billTerms = _saleInvoice.GetBillTerms();
            }
        }

        private void fillBillTerms()
        {
            dgvBillTerms.DataSource = _saleInvoice.Terms.Select(t => new BillTermView(t)).ToList();
        }

        private AccountListItem setAccount()
        {
            return _saleInvoice.Account == null ? null : new AccountListItem { Account = _saleInvoice.Account };
        }

        private DateTime getDate()
        {
            return _saleInvoice.Entity.Date == DateTime.MinValue ? DateTime.Today : _saleInvoice.Entity.Date;
        }

        #endregion

        #region Save Invoice

        protected override void ProcessSave(object sender)
        {
            ((SaleInvoice)DataSource).Save();
            OnTransactionSaved(new VoucherSavedEventArgs(_saleInvoice.Entity, CommandBar[sender]));
        }

        #endregion

        #region Set new invoice

        protected override void ProcessNew()
        {
            DataSource = new SaleInvoice(new SaleInvoiceEntity()) { Daybook = _saleInvoice.Daybook };
        }

        #endregion

        #region Item Addition

        void uLineItem_ItemAdded(object sender, ItemAddedEventArgs e)
        {
            EventHandlerExecutor.Execute(processItemAddition, sender, e);
        }

        private void processItemAddition(object sender, EventArgs e)
        {
            var args = (ItemAddedEventArgs)e;
            _saleInvoice.Lines.Add(args.Item);
            fillItemList();
            fillTotalAmount();
            fillBillTerms();
        }

        private void fillItemList()
        {
            dgvLineItems.DataSource = _saleInvoice.Lines.Select(l => new LineItemView(l)).ToList();
        }

        private void fillTotalAmount()
        {
            var totalAmount = getCalculatedAmount(_saleInvoice.Lines.Sum(l => l.Entity.Amount));
            ntbAmount.Text = totalAmount.ToString();
            ntbAmount.Value = Convert.ToDouble(totalAmount);
        }

        private decimal getCalculatedAmount(decimal amount)
        {
            foreach (var billTerm in _billTerms)
                foreach (var c in billTerm.Entity.Formula.ToCharArray())
                    updateSaleInvoiceTerm(amount, billTerm, c);

            return amount + _saleInvoice.Terms.Sum(t => t.Entity.Amount);
        }

        private void updateSaleInvoiceTerm(decimal amount, BillTerm billTerm, char c)
        {
            var invoiceTerm = _saleInvoice.Terms.SingleOrDefault(t => t.Entity.Code == billTerm.Entity.Code);
            invoiceTerm.Entity.Amount = getTermAmount(billTerm.Entity, c == 'B'
                                                ? amount
                                                : _saleInvoice.Terms.SingleOrDefault(t => t.Entity.Code == c).Entity.Amount);
        }

        private decimal getTermAmount(BillTermEntity billTermEntity, decimal amount)
        {
            switch (billTermEntity.Sign)
            {
                case '+':
                    return (decimal)((Math.Abs(billTermEntity.Percentage) / 100) * (double)amount);

                case '-':
                    return -((decimal)((Math.Abs(billTermEntity.Percentage) / 100) * (double)amount));

                case '*':
                    return (decimal)((billTermEntity.Percentage / 100) * (double)amount);

                default:
                    return 0;
            }
        }

        #endregion
    }
}
