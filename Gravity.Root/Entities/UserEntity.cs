using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Gravity.Root.Properties;

namespace Gravity.Root.Entities
{
    public class UserEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "UserNameCannotBeEmpty")]
        public string Name { get; set; }
        public Credentials Credentials { get; set; }
        public IList<UserRoleEntity> Roles { get; set; }
        public string Designation { get; set; }
        public string ParentId { get; set; }
        public string MobileNrs { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool ShowNotifications { get; set; }
        public bool AllowAdHocNrs { get; set; }

        public UserEntity()
        {
            Credentials = new Credentials();
            Roles = new List<UserRoleEntity>();
            IsActive = true;
        }

        public static UserEntity New()
        {
            return new UserEntity { Id = EntityPrefix.UserPrefix };
        }
    }
}
