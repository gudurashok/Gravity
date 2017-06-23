using System;
using Insight.Domain.Repositories;
using Insight.UC.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UChartOfAccountList : UPicklist
    {
        public UChartOfAccountList()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new ChartOfAccounts();
            FillList(true);
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Type", 120));
        }

        private void newChartOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewChartOfAccount);
        }

        void processNewChartOfAccount()
        {
            var chartOfAccountForm = new FSetup(new UChartOfAccount());
            chartOfAccountForm.ShowDialog();
            FillList(true);
        }
    }
}
