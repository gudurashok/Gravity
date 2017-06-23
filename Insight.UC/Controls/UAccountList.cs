using System;
using Insight.Domain.Repositories;
using Insight.UC.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UAccountList : UPicklist
    {
        public UAccountList()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new Accounts();
            FillList(true);
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("ChartOfAccount", 120));
        } 

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewMenuToolStripItem);
        }

        void processNewMenuToolStripItem()
        {
            var accountEntryForm = new FSetup(new UAccount());
            accountEntryForm.ShowDialog();
            FillList(true);
        }
    }
}
