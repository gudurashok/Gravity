using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Scalable.Shared.Common;

namespace Mingle.Domain.Model
{
    public class InstantMessenger
    {
        public string Label { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "InstantMessengerIdCannotBeEmpty")]
        public string IMId { get; set; }
        public string IMName { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }

        public override string ToString()
        {
            return IMId;
        }

        public string ToStringWithLabel()
        {
            return string.IsNullOrWhiteSpace(Label) ? IMId : string.Format("{0}: {1}", Label.Trim(), IMId);
        }

        public void Validate()
        {
            EntityValidator.Validate(this);
        }
    }
}
