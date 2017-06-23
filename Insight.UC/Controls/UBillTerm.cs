using System;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Common;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UBillTerm : UFormBase, ISetup
    {
        private BillTerm _billTerm;
        public event EventHandler<EventArgs> ItemSaved;

        public UBillTerm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            txbDaybook.PickList = PicklistFactory.Daybooks.Form;
        }

        public override object DataSource
        {
            get
            {
                fillObject();
                return _billTerm;
            }
            set
            {
                _billTerm = value as BillTerm;
                fillForm();
            }
        }

        private void fillForm()
        {
            txtCode.Text = _billTerm.Entity.Code.ToString();
            ntbType.Text = _billTerm.Entity.Type.ToString();
            txbDaybook.Value = getDaybook();
            txtDescription.Text = _billTerm.Entity.Description;
            txtFormula.Text = _billTerm.Entity.Formula;
            ntbPercentage.Text = _billTerm.Entity.Percentage.ToString();
            txtSign.Text = _billTerm.Entity.Sign.ToString();
        }

        private DaybookListItem getDaybook()
        {
            return _billTerm.Entity.DaybookId == null ? null : new DaybookListItem { Daybook = _billTerm.Daybook };
        }

        private void fillObject()
        {
            _billTerm.Entity.Code = Convert.ToChar(txtCode.Text = txtCode.Text == "" ? " " : txtCode.Text);
            _billTerm.Entity.Type = Convert.ToInt32(ntbType.Text);
            _billTerm.Entity.DaybookId = getDaybookId();
            _billTerm.Entity.Description = txtDescription.Text;
            _billTerm.Entity.Formula = txtFormula.Text;
            _billTerm.Entity.Percentage = Convert.ToDouble(ntbPercentage.Text);
            _billTerm.Entity.Sign = string.IsNullOrWhiteSpace(txtSign.Text) ? '+' : Convert.ToChar(txtSign.Text);
        }

        private string getDaybookId()
        {
            return txbDaybook.Value == null ? null : ((DaybookListItem)txbDaybook.Value).Daybook.Entity.Id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSaveBillTerm);
        }

        void processSaveBillTerm()
        {
            ((BillTerm)DataSource).Save();
            OnBillTermSaved(new EventArgs());
        }

        protected virtual void OnBillTermSaved(EventArgs e)
        {
            if (ItemSaved != null)
                ItemSaved(this, e);
        }
    }
}
