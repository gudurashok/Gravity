using System;
using Scalable.Shared.Model;

namespace Scalable.Win.Events
{
    public class ListItemEventArgs : EventArgs
    {
        public IListItem Item { get; set; }

        public ListItemEventArgs(IListItem item)
        {
            Item = item;
        }
    }
}
