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
    public partial class UItems : UPicklist
    {
        public UItems()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            SearchProperty = "Name";
            buildColumns();
            Repository = new Items();
            FillList(true);
            uItem.Initialize();
            uItem.ItemSaved += uItem_ItemSaved;
        }

        private void buildColumns()
        {
            ListView.Items.Clear();
            ListView.Columns.Add(new iColumnHeader("Name", true));
            //TODO: Need to be uncommented when Item group and Category entities are stored
            //ListView.Columns.Add(new iColumnHeader("Group", 100));
            //ListView.Columns.Add(new iColumnHeader("Category", 100));
        }

        private void reset()
        {
            btnCancel.Enabled = false;
            uItem.Enabled = false;
        }

        private void lvw_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EventHandlerExecutor.Execute(processSelectedItem, sender, e);
        }

        void processSelectedItem(object sender, EventArgs e)
        {
            setButtonStates();

            var args = (ListViewItemSelectionChangedEventArgs)e;
            if (!args.IsSelected) return;

            uItem.DataSource = getSelectedItem();
        }

        private Item getSelectedItem()
        {
            return ListView.HasAnyItemsSelected() 
                        ? ((ItemListItem) ListView.SelectedItems[0].Tag).Item 
                        : Item.New();
        }

        private void setButtonStates()
        {
            var enable = ListView.HasAnyItemsSelected();
            btnOK.Enabled = enable;
            btnOpen.Enabled = enable;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processNew);
        }

        void processNew()
        {
            uItem.Enabled = true;
            uItem.Enabled = true;
            btnOK.Enabled = true;
            btnOpen.Enabled = false;
            uItem.DataSource = Item.New();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processCancel);
        }

        void processCancel()
        {
            reset();
            uItem.DataSource = getSelectedItem();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processEdit);
        }

        void processEdit()
        {
            btnCancel.Enabled = true;
            uItem.Enabled = true;
            uItem.DataSource = getSelectedItem();
        }

        private void uItem_ItemSaved(object sender, EventArgs e)
        {
            reset();
            FillList(true);
        }
    }
}
