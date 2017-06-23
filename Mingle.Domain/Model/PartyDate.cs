using System;
using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Scalable.Shared.Common;

namespace Mingle.Domain.Model
{
    public class PartyDate
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DateTitleCannotBeEmpty")]
        public string Label { get; set; }
        public DateTime Value { get; set; }

        public void Validate()
        {
            EntityValidator.Validate(this);
        }

        public string DateValue
        {
            get { return Value.ToString("dd-MMM-yyyy"); }
        }

        public override string ToString()
        {
            return Value.ToShortDateString();
        }

        public string ToStringWithLabel()
        {
            return string.Format("{0}: {1}", Label, Value.ToShortDateString());
        }
    }
}
