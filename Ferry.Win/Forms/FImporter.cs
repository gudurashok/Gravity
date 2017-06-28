using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ferry.Logic.Base;
using Ferry.Logic.Common;
using Ferry.Win.Properties;
using Foresight.Logic.Common;
using Foresight.Logic.DataAccess;
using Insight.Domain.Model;
using Scalable.Win.Controls;
using Scalable.Win.Forms;
using Scalable.Shared.Common;
using Gravity.Root.Common;
using System.Diagnostics;

namespace Ferry.Win.Forms
{
    public partial class FImporter : FFormBase
    {
        #region Internal Declarations

        private Stopwatch _timer;
        private readonly DataContext _dbc;
        private DataImportContext _idc;
        private IList<CompanyPeriod> _companyPeriods { get; set; }
        private bool _isImportInProgress;
        private bool _isImportSuccess = true;

        #endregion

        #region Constructor

        public FImporter(IList<CompanyPeriod> companyPeriods)
        {
            InitializeComponent();
            _companyPeriods = companyPeriods;
            _dbc = new DataContext(GravitySession.CompanyGroup);
        }

        #endregion

        #region Initialize form

        protected override void OnLoad(EventArgs e)
        {
            EventHandlerExecutor.Execute(processLoad, this, e);
        }

        void processLoad(object sender, EventArgs e)
        {
            base.OnLoad(e);
            initializeForm();
        }

        private void initializeForm()
        {
            lblTimeElapsed.Text = string.Empty;
            setForesightCompanyPeriod();
            fillCompanyPeriods();
        }

        private void setForesightCompanyPeriod()
        {
            foreach (var cp in _companyPeriods)
                cp.Foresight = _dbc.GetForesightCompanyPeriod(cp.Entity.ForesighId);
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

        #region View import error

        private void lvwList_DoubleClick(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processViewError, sender, e);
        }

        void processViewError(object sender, EventArgs e)
        {
            var lvsi = lvwList.SelectedItems[0].SubItems[0];
            if (lvsi.Tag == null)
                return;

            MessageBoxUtil.ShowError(lvsi.Tag as Exception);
        }

        #endregion

        #region Process import

        private void btnStart_Click(object sender, EventArgs e)
        {
            Timer elapsedTimeTimer = null;

            try
            {
                elapsedTimeTimer = setupElapsedTimeTimer();
                startImport();
            }
            catch (ImportAbortException)
            {
                abortedImport();
            }
            finally
            {
                if (elapsedTimeTimer != null)
                    elapsedTimeTimer.Tick -= elapsedTimeTimer_Tick;

                Cursor = Cursors.Default;
                AcceptButton = btnOK;
            }
        }

        private Timer setupElapsedTimeTimer()
        {
            var elapsedTimeTimer = new Timer();
            elapsedTimeTimer.Interval = 1000;
            elapsedTimeTimer.Enabled = true;
            elapsedTimeTimer.Tick += elapsedTimeTimer_Tick;
            return elapsedTimeTimer;
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

        private void startImport()
        {
            Cursor = Cursors.WaitCursor;
            _timer = new Stopwatch();
            setPreImportState();
            performImport();
            _timer.Stop();
            showPostImportInfo();
        }

        private void setPreImportState()
        {
            Text = Resources.EtlInProgress;
            lblStartTime.Text = string.Format(Resources.ImportStartedAt, DateTime.Now.ToLongTimeString());
            picWaitIndicator.Visible = true;
            picWaitIndicator.Refresh();
            btnStart.Visible = false;
            pnlProgress.Visible = true;
            pnlStart.Visible = false;
            btnStart.Visible = false;
            lblProgress.Text = Resources.StartingImporting;
            btnCancel.Cursor = Cursors.Hand;
            pnlProgress.Refresh();
            _isImportInProgress = true;
        }

        private void performImport()
        {
            foreach (ListViewItem lvi in lvwList.Items)
            {
                try
                {
                    var cp = lvi.Tag as CompanyPeriod;
                    lblCompany.Text = getTitleText(cp);
                    setImportInProgress(lvi);
                    performImport(cp);
                    setImportSuccess(lvi);
                }
                catch (Exception ex)
                {
                    _dbc.UpdateIsCompanyPeriodImporting(lvi.Tag as CompanyPeriod, false, 0);
                    _isImportSuccess = false;

                    if (ex is ImportAbortException)
                        throw;

                    RootUtil.LogError(ex);
                    setImportFailed(lvi, ex);
                }
            }
        }

        private string getTitleText(CompanyPeriod cp)
        {
            return string.Format("{0}: {1}", cp.Company.Entity.Name, cp.Period.Entity.Name);
        }

        private void setImportInProgress(ListViewItem lvi)
        {
            lvi.ForeColor = Color.Blue;
            lvi.Font = new Font(lvwList.Font, FontStyle.Italic);
        }

        private void performImport(CompanyPeriod cp)
        {
            _dbc.UpdateIsCompanyPeriodImporting(cp, true, WinProcessUtil.CurrentProcessId);
            _idc = DataImporterFactory.GetDataImporter(cp);
            _idc.Importer.Importing += Importer_Importing;
            _idc.PerformImport();
            _dbc.UpdateIsCompanyPeriodImporting(cp, false, 0);
            _idc.Importer.Importing -= Importer_Importing;
        }

        private void Importer_Importing(object sender, ImportingEventArgs e)
        {
            showProgress(e.CurrentItem);
        }

        private void showProgress(string currentItem)
        {
            Application.DoEvents();
            setLabelText(lblProgress, currentItem);
        }

        private void setImportSuccess(ListViewItem lvi)
        {
            lvi.ForeColor = Color.DarkGreen;
            lvi.Font = new Font(lvwList.Font, FontStyle.Bold);
        }

        private void setImportFailed(ListViewItem lvi, Exception ex)
        {
            lvi.ForeColor = Color.Red;
            lvi.Font = new Font(lvwList.Font, FontStyle.Strikeout);
            lvi.SubItems[0].Tag = ex;
        }

        private void showPostImportInfo()
        {
            displayPostImportStatusMessage();
            setLabelText(lblProgress, "");
            _isImportInProgress = false;
            picWaitIndicator.Visible = false;
            btnCancel.Visible = false;
            btnOK.Visible = true;
        }

        private void displayPostImportStatusMessage()
        {
            if (_isImportSuccess)
            {
                lblStatus.Text = string.Format(Resources.ImportDataSuccessfull);
                lblStatus.ForeColor = Color.Blue;
            }
            else
            {
                lblStatus.Text = string.Format(Resources.ImportDataFailed);
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void abortedImport()
        {
            setLabelText(lblStatus, Resources.ImportAborted);
            setLabelText(lblProgress, "");
            Close();
        }

        #endregion

        #region Cancel import

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancelImport, sender, e);
        }

        void processCancelImport(object sender, EventArgs e)
        {
            if (!_isImportInProgress)
            {
                cancelImport();
                Close();
                return;
            }

            if (MessageBoxUtil.GetConfirmationYesNo(Resources.AreYouSureToAbortImport) != DialogResult.Yes)
                return;

            cancelImport();
        }

        private void cancelImport()
        {
            if (_isImportInProgress)
            {
                _idc.Importer.Importing -= Importer_Importing;
                setLabelText(lblProgress, "");
                setLabelText(lblStatus, Resources.AbortingImport);
                Application.DoEvents();
                _idc.Importer.CancelImport();
            }
        }

        #endregion

        #region Close

        private void btnOK_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processClose, sender, e);
        }

        void processClose(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Common

        private static void setLabelText(Label lbl, string text)
        {
            lbl.Text = text;
            lbl.Refresh();
        }

        #endregion
    }
}
