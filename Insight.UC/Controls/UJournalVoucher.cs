using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Forms;
using Insight.UC.Picklists;

namespace Insight.UC.Controls
{
    public partial class UJournalVoucher : UVoucher
    {
        public UJournalVoucher(FDaybooks fDaybooks)
            : base(fDaybooks)
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            txbAccount.PickList = PicklistFactory.Accounts.Form;
            txbDebitAccount.PickList = PicklistFactory.Accounts.Form;
        }

        protected override void FillObject()
        {
            base.FillObject();
            getJVDetails();
        }

        private void getJVDetails()
        {
            var entity = (JournalVoucherEntity)Voucher.Entity;
            entity.CreditAccountId = getCreditAccountId();
            entity.NotesCredit = rtbDescription.Text;
            entity.DebitAccountId = getDebitAccountId();
            entity.NotesDebit = rtbNotesDebit.Text;
        }

        private string getDebitAccountId()
        {
            return txbDebitAccount.Value == null ? null : ((AccountListItem)txbDebitAccount.Value).Account.Entity.Id;
        }

        private string getCreditAccountId()
        {
            return txbAccount.Value == null ? null : ((AccountListItem)txbAccount.Value).Account.Entity.Id;
        }

        protected override void FillForm()
        {
            base.FillForm();
            setBankDetails();
        }

        private void setBankDetails()
        {
            txbAccount.Value = getCreditAccount();
            rtbDescription.Text = ((JournalVoucherEntity)Voucher.Entity).NotesCredit;
            txbDebitAccount.Value = getDebitAccount();
            rtbNotesDebit.Text = ((JournalVoucherEntity)Voucher.Entity).NotesDebit;
        }

        private AccountListItem getCreditAccount()
        {
            var account = ((JournalVoucher)Voucher).CreditAccount;
            return account == null ? null : new AccountListItem { Account = account };
        }

        private AccountListItem getDebitAccount()
        {
            var account = ((JournalVoucher)Voucher).DebitAccount;
            return account == null ? null : new AccountListItem { Account = account };
        }

        protected override void ProcessNew()
        {
            DataSource = new JournalVoucher(
                new JournalVoucherEntity()) { Daybook = Voucher.Daybook };
        }
    }
}
