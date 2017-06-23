using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Gravity.Root.Properties;

namespace Gravity.Root.Entities
{
    public class UserConfigEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AppConfigItemNameCannotBeEmpty")]
        public string Name { get; set; }
        public object Value { get; set; }

        public static UserConfigEntity New()
        {
            return new UserConfigEntity { Id = EntityPrefix.UserConfigPrefix };
        }
    }
}
