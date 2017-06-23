using System;
using Synergy.Domain.Model;

namespace Synergy.UC.Events
{
    public class TaskSelectedEventArgs : EventArgs
    {
        public Task Task { get; private set; }

        public TaskSelectedEventArgs(Task task)
        {
            Task = task;
        }
    }
}
