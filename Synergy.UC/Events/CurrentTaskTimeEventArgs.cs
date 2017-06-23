using System;

namespace Synergy.UC.Events
{
    public class CurrentTaskTimeEventArgs : EventArgs
    {
        public TimeSpan TimeSpan { get; private set; }

        public CurrentTaskTimeEventArgs(TimeSpan timeSpan)
        {
            TimeSpan = timeSpan;
        }
    }
}
