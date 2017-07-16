using System.Drawing;
using System.Windows.Forms;
using Foresight.Logic.DataAccess;
using Foresight.Win.Common;
using Insight.Domain.Model;
using Gravity.Root.Model;
using System;
using Scalable.Shared.Common;

namespace Foresight.Win.Reports
{
    public partial class FReportViewer : Form
    {
        public FReportViewer(UReportBase report)
        {
            InitializeComponent();
            AddReportControl(report);
        }

        public void AddReportControl(UReportBase report)
        {
            Controls.Add(report);
            report.BringToFront();
            report.Dock = DockStyle.Fill;
            report.Show();
        }

        public static void ShowLedger(Form owner, Daybook jvDaybook)
        {
            var command = ForesightDatabaseFactory.GetInstance().GetCommandByNr(ForesightConstants.LedgerReportNr);
            var summary = new ULedgerSummaryReport(command, jvDaybook);
            var detail = new ULedgerDetailReport(command, jvDaybook);
            show(owner, summary, detail);
        }

        public static void ShowLedger(Form owner, Account account)
        {
            var command = ForesightDatabaseFactory.GetInstance().GetCommandByNr(ForesightConstants.LedgerReportNr);
            var summary = new ULedgerSummaryReport(command, account);
            var detail = new ULedgerDetailReport(command, account);
            show(owner, summary, detail);
        }

        private static void show(Form owner, ULedgerSummaryReport summary, ULedgerDetailReport detail)
        {
            detail.SummaryControl = summary;
            summary.DetailControl = detail;
            detail.Enabled = false;

            var viewer = new FReportViewer(detail);
            viewer.Size = UserConfig.ForesightLedgerReportWindowSize;
            viewer.AddReportControl(summary);
            viewer.ResizeEnd += LedgerReportViewer_ResizeEnd;
            viewer.Show(owner);
        }

        private static void LedgerReportViewer_ResizeEnd(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(saveLedgerWindowSize, sender, e);
        }

        private static void saveLedgerWindowSize(object sender, EventArgs e)
        {
            UserConfig.ForesightLedgerReportWindowSize = (sender as Form).Size;
        }
    }
}
