using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Foresight.Logic.Common;
using Foresight.Logic.Ledger;
using Foresight.Win.Properties;
using Gravity.Root.Common;
using Insight.Domain.Model;
using Scalable.Win.Controls;
using Scalable.Win.Forms;
using System.Diagnostics;
using Scalable.Shared.Common;

namespace Foresight.Win.Forms
{
    public partial class FLedgerUpdater : FFormBase
    {
        #region Internal Declarations

        private Stopwatch _timer;
        private LedgerBuilder _lb;
        private readonly IList<CompanyPeriod> _companyPeriods;
        private bool _isUpdateInProgress;
        private bool _isUpdateSuccess = true;

        #endregion

        #region Constructor

        public FLedgerUpdater(IList<CompanyPeriod> companyPeriods)
        {
            InitializeComponent();
            _companyPeriods = companyPeriods;
        }

        #endregion

        #region Initialize Load

        protected override void OnLoad(EventArgs e)
        {
            EventHandlerExecutor.Execute(processLoad, this, e);
        }

        void processLoad(object sender, EventArgs e)
        {
            base.OnLoad(e);
            fillCompanyPeriods();
            lblTimeElapsed.Text = string.Empty;
        }

        private void fillCompanyPeriods()
        {
            buildColumns();
            fillRows();
        }

        private void buildColumns()
        {
            lvwList.Columns.Clear();
            lvwList.Columns.Add(new iColumnHeader("Company", true));
            lvwList.Columns.Add(new iColumnHeader("Period", 75));
            lvwList.Width = lvwList.Width + 1;
        }

        private void fillRows()
        {
            foreach (var cp in _companyPeriods)
                lvwList.Items.Add(createCompanyPeriodListItem(cp));
        }

        private ListViewItem createCompanyPeriodListItem(CompanyPeriod cp)
        {
            var lvi = new ListViewItem();
            lvi.Tag = cp;
            lvi.Text = cp.Company.Entity.Name;
            lvi.SubItems.Add(cp.Period.Entity.Name);
            return lvi;
        }

        #endregion

        #region View updation error

        private void lvwList_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processError, sender, e);
        }

        void processError(object sender, EventArgs e)
        {
            var lvsi = lvwList.SelectedItems[0].SubItems[0];
            if (lvsi.Tag == null)
                return;

            MessageBoxUtil.ShowError(lvsi.Tag as Exception);
        }

        #endregion

        #region Process start

        private void btnStart_Click(object sender, EventArgs e)
        {
            Timer elapsedTimeTimer = null;

            try
            {
                elapsedTimeTimer = new Timer();
                elapsedTimeTimer.Interval = 1000;
                elapsedTimeTimer.Enabled = true;
                elapsedTimeTimer.Tick += elapsedTimeTimer_Tick;
                startUpdating();
                AcceptButton = btnOK;
            }
            catch (LedgerUpdateAbortException)
            {
                abortedUpdation();
            }
            finally
            {
                if (elapsedTimeTimer != null)
                    elapsedTimeTimer.Tick -= elapsedTimeTimer_Tick;

                Cursor = Cursors.Default;
            }
        }

        void elapsedTimeTimer_Tick(object sender, EventArgs e)
        {
            lblTimeElapsed.Text = string.Format("Time elapsed: {0}", getTimeSpanDisplayText(_timer.Elapsed));
        }

        private string getTimeSpanDisplayText(TimeSpan ts)
        {
            return string.Format("{0}:{1}:{2} hrs",
                                    ts.Hours.ToString("00"),
                                    ts.Minutes.ToString("00"),
                                    ts.Seconds.ToString("00"));
        }

        private void startUpdating()
        {
            Cursor = Cursors.WaitCursor;
            _timer = new Stopwatch();
            setPreUpdateState();
            performUpdate();
            _timer.Stop();
            showPostUpdateInfo();
        }

        private void setPreUpdateState()
        {
            Text = Resources.UpdateInProgress;
            lblStartTime.Text = string.Format(Resources.UpdateStartedAt, DateTime.Now.ToLongTimeString());
            picWaitIndicator.Visible = true;
            picWaitIndicator.Refresh();
            btnStart.Visible = false;
            pnlProgress.Visible = true;
            pnlStart.Visible = false;
            btnStart.Visible = false;
            lblProgress.Text = Resources.StartingUpdating;
            btnCancel.Cursor = Cursors.Hand;
            pnlProgress.Refresh();
            _isUpdateInProgress = true;
        }

        private void performUpdate()
        {
            foreach (ListViewItem lvi in lvwList.Items)
            {
                try
                {
                    var cp = lvi.Tag as CompanyPeriod;
                    lblCompany.Text = getTitleText(cp);
                    setUpdateInProgress(lvi);
                    performUpdate(cp);
                    setUpdationSuccess(lvi);
                }
                catch (Exception ex)
                {
                    _isUpdateSuccess = false;

                    if (ex is LedgerUpdateAbortException)
                        throw;

                    RootUtil.LogError(ex);
                    setUpdationFailed(lvi, ex);
                }
            }
        }

        private string getTitleText(CompanyPeriod cp)
        {
            return string.Format("{0}: {1}", cp.Company.Entity.Name, cp.Period.Entity.Name);
        }

        private void setUpdateInProgress(ListViewItem lvi)
        {
            lvi.ForeColor = Color.Blue;
            lvi.Font = new Font(lvwList.Font, FontStyle.Italic);
        }

        private void performUpdate(CompanyPeriod cp)
        {
            _lb = new LedgerBuilder(ForesightSession.Dbc, cp);
            _lb.Updating += Updater_Updating;
            _lb.BuildDimensionTables();
            _lb.Updating -= Updater_Updating;
        }

        private void Updater_Updating(object sender, UpdatingEventArgs e)
        {
            showProgress(e.CurrentItem);
        }

        private void showProgress(string currentItem)
        {
            Application.DoEvents();
            setLabelText(lblProgress, currentItem);
        }

        private void setUpdationSuccess(ListViewItem lvi)
        {
            lvi.ForeColor = Color.DarkGreen;
            lvi.Font = new Font(lvwList.Font, FontStyle.Bold);
        }

        private void showPostUpdateInfo()
        {
            displayPostUpdateStatusMessage();
            setLabelText(lblProgress, "");
            _isUpdateInProgress = false;
            picWaitIndicator.Visible = false;
            btnCancel.Visible = false;
            btnOK.Visible = true;
        }

        private void displayPostUpdateStatusMessage()
        {
            if (_isUpdateSuccess)
            {
                lblStatus.Text = string.Format(Resources.UpdateDataSuccessfull);
                lblStatus.ForeColor = Color.Blue;
            }
            else
            {
                lblStatus.Text = string.Format(Resources.UpdateDataFailed);
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void setUpdationFailed(ListViewItem lvi, Exception ex)
        {
            lvi.ForeColor = Color.Red;
            lvi.Font = new Font(lvwList.Font, FontStyle.Strikeout);
            lvi.SubItems[0].Tag = ex;
        }

        private void abortedUpdation()
        {
            setLabelText(lblStatus, Resources.UpdateAborted);
            setLabelText(lblProgress, "");
            Close();
        }

        #endregion

        #region Process cancel

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel, sender, e);
        }

        void processCancel(object sender, EventArgs e)
        {
            if (!_isUpdateInProgress)
            {
                cancelUpdation();
                Close();
                return;
            }

            if (MessageBoxUtil.GetConfirmationYesNo(Resources.AreYouSureToAbortUpdation) != DialogResult.Yes)
                return;

            cancelUpdation();
        }

        private void cancelUpdation()
        {
            if (_isUpdateInProgress)
            {
                _lb.Updating -= Updater_Updating;
                setLabelText(lblProgress, "");
                setLabelText(lblStatus, Resources.AbortingUpdation);
                Application.DoEvents();
                _lb.CancelUpdation();
            }
        }

        #endregion

        #region Close after complete

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                ExceptionProcessor.Process(ex);
            }
        }

        #endregion

        #region Common

        private void setLabelText(Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Refresh();
        }

        #endregion
    }
}
