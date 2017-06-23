using System;
using Mingle.Domain.Model;
using Scalable.Win.Enums;

namespace Mingle.UC.Events
{
    public class PartySavedEventArgs : EventArgs
    {
        public Party Party { get; private set; }
        public CommandBarActionWrapper Action { get; set; }

        public PartySavedEventArgs(Party party, CommandBarActionWrapper action)
        {
            Party = party;
            Action = action;
        }
    }
}
