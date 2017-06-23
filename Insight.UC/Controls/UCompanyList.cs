using Insight.Domain.Repositories;
using Insight.UC.Forms;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UCompanyList : UPicklist
    {
        public UCompanyList()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            buildColumns();
            SearchProperty = "Name";
            Repository = new Companies();
            FillList(true);
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Party", 100));
        }

        private void newCompanyToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewCompany);
        }

        void processNewCompany()
        {
            var companyForm = new FSetup(new UCompany());
            companyForm.ShowDialog();
            FillList(true);
        }
    }
}
