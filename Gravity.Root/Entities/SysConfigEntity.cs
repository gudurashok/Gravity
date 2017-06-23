using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Gravity.Root.Properties;

namespace Gravity.Root.Entities
{
    public class SysConfigEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AppConfigItemNameCannotBeEmpty")]
        public string Name { get; set; }
        public object Value { get; set; }

        public static SysConfigEntity New()
        {
            return new SysConfigEntity { Id = EntityPrefix.SysConfigPrefix };
        }
    }
}
