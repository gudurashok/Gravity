using System;
using Insight.Domain.Repositories;
using Insight.UC.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UFiscalDatePeriodList : UPicklist
    {
        public UFiscalDatePeriodList()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new FiscalDatePeriods();
            FillList(true);
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("FinancialYear", true));
            ListView.Columns.Add(new iColumnHeader("AssessmentYear", true));
        }

        private void newFiscalDatePeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewFiscalDatePeriod);
        }

        void processNewFiscalDatePeriod()
        {
            var fiscalDatePeriod = new FSetup(new UFiscalDatePeriod());
            fiscalDatePeriod.ShowDialog();
            FillList(true);
        }
    }
}
