using System;
using Gravity.Root.Entities;

namespace Gravity.Root.Events
{
    public class UserEventArgs : EventArgs
    {
        public UserEntity User { get; private set; }

        public UserEventArgs(UserEntity user)
        {
            User = user;
        }
    }
}
