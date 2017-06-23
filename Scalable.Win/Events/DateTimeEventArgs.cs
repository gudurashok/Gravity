using System;

namespace Scalable.Win.Events
{
    public class DateTimeEventArgs : EventArgs
    {
        public DateTime? SelectedDateTime { get; private set; }
        
        public DateTimeEventArgs(DateTime? selectedDateTime)
        {
            SelectedDateTime = selectedDateTime;
        }
    }
}
