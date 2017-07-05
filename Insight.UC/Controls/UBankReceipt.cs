using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.UC.Forms;

namespace Insight.UC.Controls
{
    public partial class UBankReceipt : UVoucher
    {
        public UBankReceipt(FDaybooks fDaybooks)
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
            ((BankReceiptEntity)Voucher.Entity).ChequeNr = txtChequeNr.Text;
            ((BankReceiptEntity)Voucher.Entity).BankBranchName = txtBankDetails.Text;
        }

        protected override void FillForm()
        {
            base.FillForm();
            setBankDetails();
        }

        private void setBankDetails()
        {
            txtChequeNr.Text = ((BankReceiptEntity)Voucher.Entity).ChequeNr;
            txtBankDetails.Text = ((BankReceiptEntity)Voucher.Entity).BankBranchName;
        }

        protected override void ProcessNew()
        {
            var oldDate = dtpDate.Value;
            DataSource = new BankReceipt(new BankReceiptEntity { Date = oldDate })
            {
                Daybook = Voucher.Daybook
            };
        }
    }
}
