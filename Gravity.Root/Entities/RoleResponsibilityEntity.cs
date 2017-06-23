using Gravity.Root.Common;

namespace Gravity.Root.Entities
{
    public class RoleResponsibilityEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public static RoleResponsibilityEntity New()
        {
            return new RoleResponsibilityEntity { Id = EntityPrefix.RoleResponsibilityPrefix };
        }
    }
}
