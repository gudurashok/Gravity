using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Scalable.Shared.Common;

namespace Mingle.Domain.Model
{
    public class CustomProperty
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CustomPropertyNameCannotBeEmpty")]
        public string Name { get; set; }
        public object Value { get; set; }
        public byte[] ValueImage { get; set; }

        public void Validate()
        {
            EntityValidator.Validate(this);
        }

        public override string ToString()
        {
            return Value == null ? string.Empty : Value.ToString();
        }
    }
}
