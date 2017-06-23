using System;

namespace Foresight.Logic.Ledger
{
    public delegate void UpdatingEventHandler(object sender, UpdatingEventArgs e);

    public class UpdatingEventArgs : EventArgs
    {
        public string CurrentItem { get; private set; }
        public bool Cancel { get; set; }

        public UpdatingEventArgs(string currentItem)
        {
            CurrentItem = currentItem;
        }
    }
}
