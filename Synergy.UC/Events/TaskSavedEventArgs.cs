using System;
using Scalable.Win.Enums;
using Synergy.Domain.Model;

namespace Synergy.UC.Events
{
    public class TaskSavedEventArgs : EventArgs
    {
        public Task Task { get; private set; }
        public CommandBarActionWrapper Action { get; private set; }

        public TaskSavedEventArgs(Task task, CommandBarActionWrapper action)
        {
            Task = task;
            Action = action;
        }
    }
}
