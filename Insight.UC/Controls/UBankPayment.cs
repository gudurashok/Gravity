using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.UC.Forms;

namespace Insight.UC.Controls
{
    public partial class UBankPayment : UVoucher
    {
        public UBankPayment(FDaybooks fDaybooks)
            : base(fDaybooks)
        {
            InitializeComponent();
        }

        protected override void FillObject()
        {
            base.FillObject();
            getBankDetails();
        }

        private void getBankDetails()
        {
            ((BankPaymentEntity)Voucher.Entity).ChequeNr = txtChequeNr.Text;
            ((BankPaymentEntity)Voucher.Entity).BankBranchName = txtBankDetails.Text;
        }

        protected override void FillForm()
        {
            base.FillForm();
            setBankDetails();
        }

        private void setBankDetails()
        {
            txtChequeNr.Text = ((BankPaymentEntity)Voucher.Entity).ChequeNr;

            txtBankDetails.Text = Voucher.Daybook.Account == null
                                        ? ((BankPaymentEntity)Voucher.Entity).BankBranchName
                                        : Voucher.Daybook.Account.Entity.Name;
        }

        protected override void ProcessNew()
        {
            DataSource = new BankPayment(
                new BankPaymentEntity()) { Daybook = Voucher.Daybook };
        }
    }
}
