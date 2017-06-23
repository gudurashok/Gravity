using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Scalable.Shared.Common;

namespace Mingle.Domain.Model
{
    public class Website
    {
        public string Label { get; set; }
        [DataType(DataType.Url, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "InvalidUrl")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "WebsiteUrlCannotBeEmpty")]
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }

        public void Validate()
        {
            EntityValidator.Validate(this);
        }

        public override string ToString()
        {
            return Url;
        }

        public string ToStringWithLabel()
        {
            return string.IsNullOrWhiteSpace(Label) ? Url : string.Format("{0}: {1}", Label.Trim(), Url);
        }
    }
}
