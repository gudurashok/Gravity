using System.Collections.Generic;
using System.Linq;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Synergy.Domain.Entities;
using Synergy.Domain.Repositories;

namespace Synergy.UC.Controls
{
    public partial class UTaskType : iListEditor
    {
        public UTaskType()
        {
            InitializeComponent();
        }

        public override void RefreshList()
        {
            refreshList(getListItems());
        }

        protected override void OnItemAdded(ListItemEventArgs e)
        {
            save(createTaskType(e.Item));
            lvwItems.SelectLastItem(true);
        }

        protected override void OnItemUpdated(ListItemEventArgs e)
        {
            save(createTaskType(e.Item));
        }

        protected override void OnItemDeleted(ListItemEventArgs e)
        {
            var repo = new TaskRepository();
            repo.DeleteTaskTypeById(e.Item.Id);
            RefreshList();
        }

        protected override void OnItemPreferred(ListItemEventArgs e)
        {
            var repo = new TaskRepository();
            repo.SetPreferredTaskType(createTaskType(e.Item));
            RefreshList();
        }

        private TaskTypeEntity createTaskType(IListItem item)
        {
            return new TaskTypeEntity
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                IsActive = item.IsActive,
                IsPreferred = item.IsPreferred
            };
        }

        private IEnumerable<IListItem> getListItems()
        {
            var repo = new TaskRepository();
            var taskTypes = repo.GetAllTaskTypes().OrderBy(t => t.Id).ToList();
            var result = new List<IListItem>();

            foreach (var taskType in taskTypes)
                result.Add(getListItem(taskType));

            return result;
        }

        private IListItem getListItem(TaskTypeEntity taskType)
        {
            return new ListItem
            {
                Id = taskType.Id,
                Name = taskType.Name,
                Description = taskType.Description,
                IsActive = taskType.IsActive,
                IsPreferred = taskType.IsPreferred
            };
        }

        private void save(TaskTypeEntity taskType)
        {
            var repo = new TaskRepository();
            repo.SaveTaskType(taskType);
            RefreshList();
        }
    }
}
