using System;
using System.Windows.Forms;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Events;
using Insight.UC.Forms;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UVoucher : UFormBase
    {
        public event EventHandler<VoucherSavedEventArgs> TransactionSaved;
        protected TransactionHeader Voucher;
        private FDaybooks _fDaybooks;

        protected UVoucher()
        {
            InitializeComponent();
        }

        protected UVoucher(FDaybooks fDaybooks)
            : this()
        {
            _fDaybooks = fDaybooks;
        }

        public virtual void Initialize()
        {
            txbAccount.PickList = PicklistFactory.Accounts.Form;
        }

        public override object DataSource
        {
            get
            {
                FillObject();
                return Voucher;
            }
            set
            {
                Voucher = value as TransactionHeader;
                FillForm();
            }
        }

        protected virtual void FillObject()
        {
            Voucher.Daybook = (Daybook)txtDaybook.Tag;
            Voucher.Entity.DaybookId = ((Daybook)txtDaybook.Tag).Entity.Id;
            Voucher.Entity.Date = dtpDate.Value;
            fillAccount();
            Voucher.Entity.Amount = Convert.ToDecimal(ntbAmount.Text);
            Voucher.Entity.Notes = rtbDescription.Text;
        }

        private void fillAccount()
        {
            Voucher.Account = txbAccount.Value == null ? null : ((AccountListItem)txbAccount.Value).Account;
            Voucher.Entity.AccountId = Voucher.Account == null ? null : Voucher.Account.Entity.Id;
        }

        protected virtual void FillForm()
        {
            txtDaybook.Tag = Voucher.Daybook;
            txtDaybook.Text = Voucher.Daybook.Entity.Name;
            txtDocNr.Text = Voucher.Entity.DocumentNr;
            dtpDate.Value = getDate();
            txbAccount.Value = setAccount();
            ntbAmount.Text = Voucher.Entity.Amount.ToString();
            ntbAmount.Value = Convert.ToDouble(Voucher.Entity.Amount);
            rtbDescription.Text = Voucher.Entity.Notes;
            ntbAmount.Select();
            txbAccount.Select();
        }

        private AccountListItem setAccount()
        {
            return Voucher.Account == null ? null : new AccountListItem { Account = Voucher.Account };
        }

        private DateTime getDate()
        {
            return Voucher.Entity.Date == DateTime.MinValue 
                            ? DateTime.Today 
                            : Voucher.Entity.Date;
        }

        private void commandBarButton_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCommandButtons, sender);
        }

        void processCommandButtons(object sender)
        {
            if (CommandBar[sender].IsSave())
                ProcessSave(sender);

            if (CommandBar[sender].IsNew())
                ProcessNew();
        }

        protected virtual void ProcessSave(object sender)
        {
            ((TransactionHeader)DataSource).Save();
            OnTransactionSaved(new VoucherSavedEventArgs(Voucher.Entity, CommandBar[sender]));
        }

        protected virtual void ProcessNew()
        {
            throw new NotImplementedException("This method should have been overridden by derived class");
        }

        protected void OnTransactionSaved(VoucherSavedEventArgs e)
        {
            TransactionSaved?.Invoke(this, e);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(changeDaybook);
        }

        void changeDaybook()
        {
            _fDaybooks = new FDaybooks(Voucher.Daybook.Entity.Type);
            if (_fDaybooks.ShowDialog() != DialogResult.OK)
                return;

            Voucher.Daybook = _fDaybooks.Daybook;
            txtDaybook.Tag = Voucher.Daybook;
            txtDaybook.Text = Voucher.Daybook.Entity.Name;
        }
    }
}
