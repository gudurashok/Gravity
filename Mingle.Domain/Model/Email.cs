using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Scalable.Shared.Common;

namespace Mingle.Domain.Model
{
    public class Email
    {
        public string Label { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "InvalidEmailAddress")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailIdCannotBeEmpty")]
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }

        public override string ToString()
        {
            return EmailId;
        }

        public string ToStringWithLabel()
        {
            return string.IsNullOrWhiteSpace(Label)
                       ? EmailId
                       : string.Format("{0}: {1}", Label.Trim(), EmailId);
        }

        public void Validate()
        {
            EntityValidator.Validate(this);
        }
    }
}
