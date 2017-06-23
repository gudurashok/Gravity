using System;
using Mingle.Domain.Model;

namespace Mingle.UC.Events
{
    public class PartySelectedEventArgs : EventArgs
    {
        public Party Party { get; private set; }

        public PartySelectedEventArgs(Party party)
        {
            Party = party;
        }
    }
}
