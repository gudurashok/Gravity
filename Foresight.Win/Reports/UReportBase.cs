using System.Collections.Generic;
using System.Windows.Forms;
using Foresight.Logic.Report;
using System.Reflection;
using System.Globalization;
using Gravity.Root.Model;
using Insight.Domain.Enums;
using Insight.Domain.Model;
using Scalable.Shared.Common;

namespace Foresight.Win.Reports
{
    public partial class UReportBase : UserControl
    {
        #region Declarations

        protected IList<CompanyPeriod> SelectedCoPeriods;
        protected const ReportsAmountFormat AmountFormat = ReportsAmountFormat.Lacs;
        protected ReportDataContext rdc { get; set; }
        protected Command Command;

        #endregion

        #region Constructor

        public UReportBase()
        {
            InitializeComponent();
        }

        public UReportBase(Command command)
            : this()
        {
            Command = command;
            rdc = ReportDataContext.CreateInstance(command);
            SelectedCoPeriods = new List<CompanyPeriod>();
            initializeReport();
        }

        #endregion

        #region Factory Method

        public static UReportBase CreateInstance(Command command)
        {
            var asm = Assembly.GetExecutingAssembly();
            return asm.CreateInstance("Foresight.Win.Reports." + command.UIControlName, true,
                    BindingFlags.Default, null, new object[] { command }, null, null) as UReportBase;
        }

        #endregion

        #region Internal Methods

        private void initializeReport()
        {
            lblTitle.Text = Command.Title;
            lblDescription.Text = Command.Description;
        }

        protected void Close()
        {
            rdc.Dispose();
            Parent.Parent.Controls.Remove(Parent);
        }

        protected ReportsAmountFormat defaultReportAmountFormat()
        {
            return ReportsAmountFormat.Crores;
        }

        protected string formatAmount(decimal value, ListControl control)
        {
            return formatAmount(value, control, false);
        }

        protected string formatAmount(decimal value, ListControl control, bool withDbCr)
        {
            return (value / Scalable.Shared.Common.AmountFormat.Value(control)).ToString(withDbCr ? CommonUtil.AmountFormatWithCrDb : "##,##,##0.00");
        }

        protected string formatAmountWithBlank(decimal value, ListControl control)
        {
            return (value / Scalable.Shared.Common.AmountFormat.Value(control)).ToString(CommonUtil.AmountFormatBlankWhenZero);
        }

        protected bool selectCompanyPeriods(CompanyPeriodType type)
        {
            var coSelectionDialog = new FCompanyPeriods(SelectedCoPeriods, type);
            var result = coSelectionDialog.ShowDialog();

            if (result == DialogResult.Cancel)
                return false;

            SelectedCoPeriods = coSelectionDialog.GetSelectedCoPeriods();
            return true;
        }

        protected string getMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
        }

        #endregion
    }
}
