using System;
using System.Windows.Forms;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UBillTerms : UPicklist
    {
        public UBillTerms()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            SearchProperty = "Description";
            buildColumns();
            Repository = new BillTerms();
            FillList(true);
            uBillTerm.Initialize();
            uBillTerm.ItemSaved += uBillTerm_BillTermSaved;
        }

        private void buildColumns()
        {
            ListView.Items.Clear();
            ListView.Columns.Add(new iColumnHeader("Description", true));
            ListView.Columns.Add(new iColumnHeader("Name", 100));
            ListView.Columns.Add(new iColumnHeader("Code",50));
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNew);
        }

        void processNew()
        {
            btnCancel.Enabled = true;
            uBillTerm.Enabled = true;
            btnOpen.Enabled = false;
            uBillTerm.DataSource = BillTerm.New();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uBillTerm.DataSource = getSelectedBillTerm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEdit);
        }

        void processEdit()
        {
            btnCancel.Enabled = true;
            uBillTerm.Enabled = true;
            uBillTerm.DataSource = getSelectedBillTerm();
        }

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedBillTerm, sender, e);
        }

        void processSelectedBillTerm(object sender, EventArgs e)
        {
            setButtonStates();

            if (uBillTerm.Enabled)
                return;

            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected) return;

            uBillTerm.DataSource = getSelectedBillTerm();
        }

        private BillTerm getSelectedBillTerm()
        {
            if (!ListView.HasAnyItemsSelected())
                return new BillTerm(new BillTermEntity());

            return ((BillTermListItem)ListView.SelectedItems[0].Tag).BillTerm;
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uBillTerm.Enabled = false;
        }

        private void setButtonStates()
        {
            var enable = ListView.HasAnyItemsSelected();
            btnOK.Enabled = enable;
            btnOpen.Enabled = enable;
        }

        void uBillTerm_BillTermSaved(object sender, EventArgs e)
        {
            reset();
            FillList(true);
        }
    }
}
