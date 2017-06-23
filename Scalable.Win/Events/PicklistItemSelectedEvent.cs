using System;

namespace Scalable.Win.Events
{
    public delegate void PicklistItemSelectedEventHandler(object sender, PicklistItemEventArgs e);

    public class PicklistItemEventArgs : EventArgs
    {
        //TODO e.PicklistItem has to be plural/array
        public object PicklistItem { get; private set; }

        public PicklistItemEventArgs(object item)
        {
            PicklistItem = item;
        }
    }
}
