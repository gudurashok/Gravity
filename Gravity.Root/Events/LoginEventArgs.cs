using System;
using Gravity.Root.Model;

namespace Gravity.Root.Events
{
    public class LoginEventArgs : EventArgs
    {
        public User User { get; private set; }

        public LoginEventArgs(User user)
        {
            User = user;
        }
    }
}
