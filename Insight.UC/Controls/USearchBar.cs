using System;
using System.Windows.Forms;
using Insight.Domain.Common;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Events;
using Insight.UC.Picklists;
using Scalable.Shared.Common;
using Scalable.Shared.Model;

namespace Insight.UC.Controls
{
    public partial class USearchBar : UserControl
    {
        public event EventHandler<VoucherSearchEventArgs> Search;

        public USearchBar()
        {
            InitializeComponent();
        }

        #region Initialize

        public void Initialize()
        {
            txbAccount.PickList = PicklistFactory.Accounts.Form;
            txbDaybook.PickList = PicklistFactory.Daybooks.Form;
            resetDatePeriod();
        }

        #endregion

        #region Create search criteria

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processSearch);
        }

        void processSearch()
        {
            var criteria = new VoucherSearchCriteria();
            criteria.DocumentNr = txtDocumentNr.Text.Trim();
            criteria.AccountId = getAccountId();
            criteria.AccountName = getAccountName();
            criteria.DaybookId = getDaybookId();
            criteria.DaybookName = getDaybookName();
            criteria.Period = getDatePeriod();
            criteria.MinAmount = Convert.ToDecimal(ntbMinAmount.Value);
            criteria.MaxAmount = Convert.ToDecimal(ntbMaxAmount.Value);
            OnSearch(new VoucherSearchEventArgs(criteria));
        }

        private string getAccountId()
        {
            return txbAccount.Value == null ? null : ((AccountListItem)txbAccount.Value).Account.Entity.Id;
        }

        private string getAccountName()
        {
            return txbAccount.Value == null ? null : ((AccountListItem)txbAccount.Value).Account.Entity.Name;
        }

        private string getDaybookId()
        {
            return txbDaybook.Value == null ? null : ((DaybookListItem)txbDaybook.Value).Daybook.Entity.Id;
        }

        private string getDaybookName()
        {
            return txbDaybook.Value == null ? null : ((DaybookListItem)txbDaybook.Value).Daybook.Entity.Name;
        }

        private DatePeriod getDatePeriod()
        {
            var result = new DatePeriod();
            result.From = dtpFrom.Checked
                            ? dtpFrom.Value.Date
                            : InsightSession.CompanyPeriod.Period.Entity.Financial.From.Date;
            result.To = dtpTo.Checked ? dtpTo.Value.Date : DateTime.Today.Date;
            return result;
        }

        protected virtual void OnSearch(VoucherSearchEventArgs e)
        {
            if (Search != null)
                Search(this, e);
        }

        #endregion

        #region Reset search criteria

        private void btnReset_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(resetSearchBar);
        }

        void resetSearchBar()
        {
            resetControls();
            OnSearch(new VoucherSearchEventArgs(new VoucherSearchCriteria()));
        }

        private void resetControls()
        {
            txbAccount.Value = null;
            txbDaybook.Value = null;
            txtDocumentNr.Text = string.Empty;
            resetDatePeriod();
            resetAmounts();
        }

        private void resetDatePeriod()
        {
            dtpFrom.Value = InsightSession.CompanyPeriod.Period.Entity.Financial.From;
            dtpTo.Value = DateTime.Today.Date;
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
        }

        private void resetAmounts()
        {
            ntbMinAmount.Value = 0;
            ntbMinAmount.Text = @"0";
            ntbMaxAmount.Value = 0;
            ntbMaxAmount.Text = @"0";
        }

        #endregion
    }
}
