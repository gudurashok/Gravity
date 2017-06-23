using System;
using System.Collections.Generic;
using Gravity.Root.Entities;

namespace Gravity.Root.Events
{
    public class ResponsibilityEventArgs : EventArgs
    {
        public IList<RoleResponsibilityEntity> RoleResponsibilityEntities;

        public ResponsibilityEventArgs(List<RoleResponsibilityEntity> roleResponsibilityEntities)
        {
            RoleResponsibilityEntities = roleResponsibilityEntities;
        }
    }
}
