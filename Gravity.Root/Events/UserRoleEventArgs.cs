using System;
using System.Collections.Generic;
using Gravity.Root.Entities;

namespace Gravity.Root.Events
{
    public class UserRoleEventArgs : EventArgs
    {
        public IList<UserRoleEntity> UserRoleEntities;

        public UserRoleEventArgs(List<UserRoleEntity> userRoleEntities)
        {
            UserRoleEntities = userRoleEntities;
        }
    }
}
