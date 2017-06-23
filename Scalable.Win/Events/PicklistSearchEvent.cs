using System;

namespace Scalable.Win.Events
{
    public delegate void PicklistSearchEventHandler(object sender, PicklistSearchEventArgs e);

    public class PicklistSearchEventArgs : EventArgs
    {
        public PicklistSearchResult Result { get; set; }
        public string SearchText { get; private set; }

        public PicklistSearchEventArgs(string searchText)
        {
            SearchText = searchText;
        }
    }
}
