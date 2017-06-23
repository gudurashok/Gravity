using System;
using Synergy.Domain.Entities;

namespace Synergy.UC.Events
{
    public class TaskCommentEventArgs : EventArgs
    {
        public TaskCommentEntity Comment { get; private set; }

        public TaskCommentEventArgs(TaskCommentEntity comment)
        {
            Comment = comment;
        }
    }
}
