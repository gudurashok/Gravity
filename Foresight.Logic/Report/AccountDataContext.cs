using Foresight.Logic.Common;
using Insight.Domain.Enums;

namespace Foresight.Logic.Report
{
    public class AccountDataContext : ReportDataContext
    {
        public AccountTypes AccountTypes { private get; set; }
        public bool OnlyDaybooks { private get; set; }

        public override ReportData GetReportData()
        {
            if (OnlyDaybooks)
                return new ReportData(ForesightSession.Dbc.GetDaybooks());

            return new ReportData(ForesightSession.Dbc.GetTrialBalances());
        }
    }
}
