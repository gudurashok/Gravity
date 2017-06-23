using System;
using System.Windows.Forms;
using Insight.Domain.Entities;
using Insight.Domain.Model;
using Insight.Domain.ViewModel;
using Insight.UC.Events;
using Insight.UC.Picklists;
using Scalable.Shared.Common;

namespace Insight.UC.Controls
{
    public partial class ULineItem : UserControl
    {
        public event EventHandler<ItemAddedEventArgs> ItemAdded;

        public ULineItem()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            txbItem.PickList = PicklistFactory.Items.Form;
        }

        protected virtual void OnItemAdded(ItemAddedEventArgs e)
        {
            if (ItemAdded != null)
                ItemAdded(this, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EventHandlerExecutor.Execute(processItemAddtion);
        }

        void processItemAddtion()
        {
            var lineItem = SaleInvoiceLine.New();
            lineItem.Item = getItem();
            lineItem.Entity.ItemId = lineItem.Item == null ? null : lineItem.Item.Entity.Id;
            lineItem.Entity.Quantity1 = ntbQty.Value;
            ((SaleInvoiceLineEntity)lineItem.Entity).Price = Convert.ToDecimal(ntbPrice.Value);
            lineItem.Entity.Amount = getAmount(lineItem.Entity);
            lineItem.Validate();
            OnItemAdded(new ItemAddedEventArgs(lineItem));
        }

        private decimal getAmount(InvoiceLineEntity entity)
        {
            return Convert.ToDecimal(entity.Quantity1) * ((SaleInvoiceLineEntity)entity).Price;
        }

        private Item getItem()
        {
            return txbItem.Value == null ? null : ((ItemListItem)txbItem.Value).Item;
        }
    }
}
