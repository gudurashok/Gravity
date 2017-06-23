using System.Collections.Generic;
using System.Linq;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Synergy.Domain.Entities;

namespace Synergy.UC.Controls
{
    public partial class UChecklistItem : iListEditor
    {
        private IList<ChecklistItemEntity> _checklistItems;
        private IList<IListItem> _items;

        public UChecklistItem()
        {
            InitializeComponent();
        }

        public override void Initiliaze()
        {
            buildColoumns();
            base.Initiliaze();
            btnPreferred.Visible = false;
            btnDescription.Visible = false;
            chkIsActive.Visible = false;
            setButtonStates();
        }

        private void buildColoumns()
        {
            lvwItems.Columns.Add(new iColumnHeader("Nr"));
        }

        public void LoadItems(IList<ChecklistItemEntity> items)
        {
            _checklistItems = items;
            _items = _checklistItems.Select(getListItem).ToList();
            RefreshList();
        }

        private IListItem getListItem(ChecklistItemEntity checklistItem)
        {
            return new ListItem
            {
                Nr = checklistItem.Nr,
                Name = checklistItem.Name,
            };
        }

        public override void RefreshList()
        {
            refreshList(_items);
            setButtonStates();
        }

        private void setButtonStates()
        {
            btnDelete.Enabled = lvwItems.HasItems();
            btnUpdate.Enabled = lvwItems.HasItems();
        }

        protected override void OnItemAdded(ListItemEventArgs e)
        {
            e.Item.Nr = _items.Count() + 1;
            _items.Add(e.Item);
            _checklistItems.Add(createChecklistItemFrom(e.Item));
            RefreshList();
            base.OnItemAdded(e);
            lvwItems.SelectLastItem(true);
        }

        private ChecklistItemEntity createChecklistItemFrom(IListItem item)
        {
            return new ChecklistItemEntity
            {
                Nr = item.Nr,
                Name = item.Name
            };
        }

        protected override void OnItemUpdated(ListItemEventArgs e)
        {
            var checklistItem = _checklistItems.FirstOrDefault(i => i.Nr == e.Item.Nr);
            checklistItem.Name = e.Item.Name;
            RefreshList();
            base.OnItemUpdated(e);
        }

        protected override void OnItemDeleted(ListItemEventArgs e)
        {
            var checklistItem = _checklistItems.FirstOrDefault(i => i.Nr == e.Item.Nr);
            _checklistItems.Remove(checklistItem);
            _items.Remove(e.Item);
            RefreshList();
            base.OnItemDeleted(e);
        }

        public IList<ChecklistItemEntity> GetChecklistItems()
        {
            var checklistItems = _items.Select(createChecklistItem).ToList();
            return checklistItems;
        }

        private ChecklistItemEntity createChecklistItem(IListItem item)
        {
            return new ChecklistItemEntity
            {
                Nr = item.Nr,
                Name = item.Name
            };
        }
    }
}
