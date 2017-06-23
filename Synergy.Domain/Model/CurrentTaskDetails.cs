using System;

namespace Synergy.Domain.Model
{
    public class CurrentTaskDetails
    {
        public DateTime? StartTime { get; set; }
        public string TaskNr { get; set; }
        public TimeSpan TotalDuration { get; set; }

        public CurrentTaskDetails()
        {
            TotalDuration = new TimeSpan();
        }
    }
}
