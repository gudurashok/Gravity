using System.Collections.Generic;
using System.Linq;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Synergy.Domain.Entities;
using Synergy.Domain.Repositories;

namespace Synergy.UC.Controls
{
    public partial class UChecklist : iListEditor
    {
        private IEnumerable<ChecklistEntity> _checklists;

        public UChecklist()
        {
            InitializeComponent();
        }

        public override void Initiliaze()
        {
            base.Initiliaze();
            btnPreferred.Visible = false;
            uChecklistItem.Initiliaze();
            uChecklistItem.ItemAdded += saveChecklist;
            uChecklistItem.ItemUpdated += saveChecklist;
            uChecklistItem.ItemDeleted += saveChecklist;
            RefreshList();
        }

        void saveChecklist(object sender, ListItemEventArgs e)
        {
            save(getSelectedItem());
        }

        public override void RefreshList()
        {
            var repo = new TaskRepository();
            _checklists = repo.GetAllChecklists().OrderBy(c => c.Id).ToList();
            refreshList(getListItems());
            setChecklistItemState();
        }

        private void setChecklistItemState()
        {
            if(!lvwItems.HasItems())
                uChecklistItem.LoadItems(new List<ChecklistItemEntity>());

            uChecklistItem.Enabled = lvwItems.HasItems();
        }

        protected override void OnItemSelected(ListItemEventArgs e)
        {
            base.OnItemSelected(e);
            uChecklistItem.LoadItems(getChecklistItemsOf(e.Item));
            lvwItems.Focus();
        }

        private IList<ChecklistItemEntity> getChecklistItemsOf(IListItem item)
        {
            var checklist = _checklists.SingleOrDefault(l => l.Id == item.Id);
            return checklist ==  null ? null : checklist.Items;
        }

        protected override void OnItemAdded(ListItemEventArgs e)
        {
            save(createChecklistFrom(e.Item));
        }

        protected override void OnItemUpdated(ListItemEventArgs e)
        {
            save(createChecklistFrom(e.Item));
        }

        protected override void OnItemDeleted(ListItemEventArgs e)
        {
            var repo = new TaskRepository();
            repo.DeleteTaskChecklistById(e.Item.Id);
            RefreshList();
        }

        private ChecklistEntity createChecklistFrom(IListItem item)
        {
            var checklist = new ChecklistEntity
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                IsActive = item.IsActive
            };

            if (!string.IsNullOrWhiteSpace(item.Id))
                checklist.Items = uChecklistItem.GetChecklistItems();

            return checklist;
        }

        private IEnumerable<IListItem> getListItems()
        {
            return _checklists.Select(getListItemOf).ToList();
        }

        private IListItem getListItemOf(ChecklistEntity checklist)
        {
            return new ListItem
            {
                Id = checklist.Id,
                Name = checklist.Name,
                Description = checklist.Description,
                IsActive = checklist.IsActive,
            };
        }

        private ChecklistEntity getSelectedItem()
        {
            var item = lvwItems.SelectedItems[0].Tag as IListItem;
            return createChecklistFrom(item);
        }

        private void save(ChecklistEntity checklist)
        {
            var repo = new TaskRepository();
            repo.SaveTaskChecklist(checklist);
            RefreshList();
        }
    }
}
