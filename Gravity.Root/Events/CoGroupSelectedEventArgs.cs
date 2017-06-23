using System;

namespace Gravity.Root.Events
{
    public class OpenCoGroupEventArgs : EventArgs
    {
        public bool IsCoGroupChanged { get; private set; }

        public OpenCoGroupEventArgs(bool isCoGroupChanged)
        {
            IsCoGroupChanged = isCoGroupChanged;
        }
    }
}
