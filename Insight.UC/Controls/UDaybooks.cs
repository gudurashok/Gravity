using System;
using System.Windows.Forms;
using Insight.Domain.Model;
using Insight.Domain.Repositories;
using Insight.Domain.ViewModel;
using Scalable.Shared.Common;
using Scalable.Win.Controls;
using Scalable.Win.FormControls;

namespace Insight.UC.Controls
{
    public partial class UDaybooks : UPicklist
    {
        public UDaybooks()
        {
            InitializeComponent();
        }

        #region Initialization

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new Daybooks();
            FillList(true);
            uDaybook.Initialize();
            uDaybook.ItemSaved += uDaybook_DaybookSaved;
        }

        private void buildColumns()
        {
            ListView.Columns.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            ListView.Columns.Add(new iColumnHeader("Type", 90));
        }

        #endregion

        private void setButtonStates()
        {
            var enable = ListView.HasAnyItemsSelected();
            btnOK.Enabled = enable;
            btnOpen.Enabled = enable;
            btnDelete.Enabled = enable;
            btnPreferred.Enabled = enable;
        }

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            if (uDaybook.Enabled)
                return;
            
            setButtonStates();
            uDaybook.DataSource = getSelectedDaybook();
        }

        private Daybook getSelectedDaybook()
        {
            return ListView.HasAnyItemsSelected()
                       ? ((DaybookListItem) ListView.SelectedItems[0].Tag).Daybook
                       : Daybook.New();
        }

        void uDaybook_DaybookSaved(object sender, EventArgs e)
        {
            reset();
            FillList(true);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNewDaybook);
        }

        void processNewDaybook()
        {
            btnCancel.Enabled = true;
            uDaybook.Enabled = true;
            uDaybook.DataSource = Daybook.New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEditDaybook);
        }

        void processEditDaybook()
        {
            btnCancel.Enabled = true;
            uDaybook.Enabled = true;
            uDaybook.DataSource = getSelectedDaybook();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uDaybook.DataSource = getSelectedDaybook();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
                reset();
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uDaybook.Enabled = false;
        }
    }
}
