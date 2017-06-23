using System.Collections.Generic;
using System.Linq;
using Scalable.Shared.Model;
using Scalable.Win.Controls;
using Scalable.Win.Events;
using Synergy.Domain.Entities;
using Synergy.Domain.Repositories;

namespace Synergy.UC.Controls
{
    public partial class ULocation : iListEditor
    {
        public ULocation()
        {
            InitializeComponent();
        }

        public override void RefreshList()
        {
            refreshList(getListItems());
        }

        protected override void OnItemAdded(ListItemEventArgs e)
        {
            save(createLocation(e.Item));
        }

        protected override void OnItemUpdated(ListItemEventArgs e)
        {
            save(createLocation(e.Item));
        }

        protected override void OnItemDeleted(ListItemEventArgs e)
        {
            var repo = new TaskRepository();
            repo.DeleteLocationById(e.Item.Id);
            RefreshList();
        }

        protected override void OnItemPreferred(ListItemEventArgs e)
        {
            var repo = new TaskRepository();
            repo.SetPreferredLocation(createLocation(e.Item));
            RefreshList();
        }

        private LocationEntity createLocation(IListItem item)
        {
            return new LocationEntity
            {
                Id = item.Id,
                Name = item.Name,
                IsActive = item.IsActive,
                IsPreferred = item.IsPreferred
            };
        }

        private IEnumerable<IListItem> getListItems()
        {
            var repo = new TaskRepository();
            var locations = repo.GetAllLocations().OrderBy(l => l.Id).ToList();
            var result = new List<IListItem>();

            foreach (var location in locations)
                result.Add(getListItem(location));

            return result;
        }

        private IListItem getListItem(LocationEntity location)
        {
            return new ListItem
            {
                Id = location.Id,
                Name = location.Name,
                IsActive = location.IsActive,
                IsPreferred = location.IsPreferred
            };
        }

        private void save(LocationEntity location)
        {
            var repo = new TaskRepository();
            repo.SaveLocation(location);
            RefreshList();
        }
    }
}
