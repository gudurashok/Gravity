using System.Collections.Generic;
using Gravity.Root.Common;

namespace Gravity.Root.Entities
{
    public class UserRoleEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public IList<RoleResponsibilityEntity> Responsibilities { get; set; }

        public UserRoleEntity()
        {
            Responsibilities = new List<RoleResponsibilityEntity>();
        }

        public static UserRoleEntity New()
        {
            return new UserRoleEntity { Id = EntityPrefix.UserRolePrefix };
        }
    }
}
