using System;
using Synergy.Domain.Model;

namespace Synergy.UC.Events
{
    public class TaskSearchEventArgs : EventArgs
    {
        public TaskSearchCriteria Criteria { get; private set; }

        public TaskSearchEventArgs(TaskSearchCriteria criteria)
        {
            Criteria = criteria;
        }
    }
}
