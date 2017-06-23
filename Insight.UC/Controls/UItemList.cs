using System;
using Insight.Domain.Repositories;
using Insight.UC.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UItemList : UPicklist
    {
        public UItemList()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new Items();
            FillList(true);
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewMenuToolStripItem);
        }

        void processNewMenuToolStripItem()
        {
            var itemEntryForm = new FSetup(new UItem());
            itemEntryForm.ShowDialog();
            FillList(true);
        }
    }
}
