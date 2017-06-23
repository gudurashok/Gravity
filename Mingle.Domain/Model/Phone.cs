using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Scalable.Shared.Common;

namespace Mingle.Domain.Model
{
    public class Phone
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PhoneLabelCannotBeEmpty")]
        public string Label { get; set; }
        [StringLength(18, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PhoneNrExceededMaxLength")]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PhoneNrCannotBeEmpty")]
        public string Nr { get; set; }
        public bool IsPreferred { get; set; }
        public bool IsActive { get; set; }

        //public bool Equals(Phone phone)
        //{
        //    return Entity.Nr == phone.Entity.Nr;
        //}

        public override string ToString()
        {
            return Nr;
        }

        public string ToStringWithLabel()
        {
            return string.IsNullOrWhiteSpace(Label)
                            ? Nr
                            : string.Format("{0}: {1}", Label.Trim(), Nr);
        }

        public void Validate()
        {
            EntityValidator.Validate(this);
        }
    }
}
