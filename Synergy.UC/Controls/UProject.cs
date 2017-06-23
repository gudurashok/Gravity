using System.Collections.Generic;
using System.Linq;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Synergy.Domain.Entities;
using Synergy.Domain.Repositories;

namespace Synergy.UC.Controls
{
    public partial class UProject : iListEditor
    {
        public UProject()
        {
            InitializeComponent();
        }

        public override void RefreshList()
        {
            refreshList(getListItems());
        }

        protected override void OnItemAdded(ListItemEventArgs e)
        {
            save(createProject(e.Item));
        }

        protected override void OnItemUpdated(ListItemEventArgs e)
        {
            save(createProject(e.Item));
        }

        protected override void OnItemDeleted(ListItemEventArgs e)
        {
            var repo = new TaskRepository();
            repo.DeleteProjectById(e.Item.Id);
            RefreshList();
        }

        protected override void OnItemPreferred(ListItemEventArgs e)
        {
            var repo = new TaskRepository();
            repo.SetPreferredProject(createProject(e.Item));
            RefreshList();
        }

        private ProjectEntity createProject(IListItem item)
        {
            return new ProjectEntity
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
            var projects = repo.GetAllProjects().OrderBy(p => p.Id).ToList();
            var result = new List<IListItem>();

            foreach (var project in projects)
                result.Add(getListItem(project));

            return result;
        }

        private IListItem getListItem(ProjectEntity project)
        {
            return new ListItem
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                IsActive = project.IsActive,
                IsPreferred = project.IsPreferred
            };
        }

        private void save(ProjectEntity project)
        {
            var repo = new TaskRepository();
            repo.SaveProject(project);
            RefreshList();
        }
    }
}
