using System.ComponentModel.DataAnnotations;
using System.Text;
using Raven.Imports.Newtonsoft.Json;
using Scalable.Shared.Common;

namespace Mingle.Domain.Model
{
    public class PartyAddress
    {
        public Address Address { get; set; }

        public string Label { get; set; }
        public string UsageLabel { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }

        [JsonIgnore]
        public string AddressString
        {
            get { return ToString(); }
        }

        [JsonIgnore]
        public string AddressWithLabels
        {
            get { return ToStringWithLabels(); }
        }

        [JsonIgnore]
        public string AddressAreaAndCity
        {
            get { return ToStringAreaAndCity(); }
        }

        public PartyAddress()
        {
            Address = new Address();
        }

        public override string ToString()
        {
            var fullAddress = new StringBuilder(Address.Street)
                .Append(string.IsNullOrWhiteSpace(Address.Area) ? string.Empty : ", " + Address.Area)
                .Append(string.IsNullOrWhiteSpace(Address.Landmark) ? string.Empty : ", " + Address.Landmark)
                .Append(string.IsNullOrWhiteSpace(Address.City) ? string.Empty : ", " + Address.City)
                .Append(string.IsNullOrWhiteSpace(Address.State) ? string.Empty : ", " + Address.State)
                .Append(string.IsNullOrWhiteSpace(Address.Country) ? string.Empty : ", " + Address.Country)
                .Append(string.IsNullOrWhiteSpace(Address.PinCode) ? string.Empty : ", " + Address.PinCode);

            return trimCommas(fullAddress.ToString());
        }

        public string ToStringWithLabels()
        {
            var fullAddress = new StringBuilder()
                .Append(string.IsNullOrWhiteSpace(Address.Street) ? string.Empty : "STREET: " + Address.Street + ", ")
                .Append(string.IsNullOrWhiteSpace(Address.Area) ? string.Empty : "AREA: " + Address.Area + ", ")
                .Append(string.IsNullOrWhiteSpace(Address.Landmark) ? string.Empty : "LANDMARK: " + Address.Landmark + ", ")
                .Append("\n")
                .Append(string.IsNullOrWhiteSpace(Address.City) ? string.Empty : "CITY: " + Address.City + ", ")
                .Append(string.IsNullOrWhiteSpace(Address.State) ? string.Empty : "STATE: " + Address.State + ", ")
                .Append("\n")
                .Append(string.IsNullOrWhiteSpace(Address.Country) ? string.Empty : "COUNTRY: " + Address.Country + ", ")
                .Append(string.IsNullOrWhiteSpace(Address.PinCode) ? string.Empty : "PINCODE: " + Address.PinCode);

            return fullAddress.ToString();
        }

        public string ToStringAreaAndCity()
        {
            var shortAddress = new StringBuilder()
                .Append(string.IsNullOrWhiteSpace(Address.Area) ? string.Empty : Address.Area + ", ")
                .Append(string.IsNullOrWhiteSpace(Address.City) ? string.Empty : Address.City);

            return trimCommas(shortAddress.ToString());
        }

        private string trimCommas(string value)
        {
            if (value.StartsWith(","))
                value = value.Remove(0, 1).Trim();

            if (value.EndsWith(", "))
                value = value.Remove(value.Length - 2, 2).Trim();

            return value;
        }

        public bool IsEmpty()
        {
            var sb = new StringBuilder(Address.Street)
                .Append(Address.Area)
                .Append(Address.Landmark)
                .Append(Address.City)
                .Append(Address.State)
                .Append(Address.Country)
                .Append(Address.PinCode);

            var result = sb.ToString().Trim();
            return result.Length == 0;
        }

        public PartyAddress GetCopy()
        {
            var address = new PartyAddress();
            address.Address.Street = Address.Street;
            address.Address.Area = Address.Area;
            address.Address.Landmark = Address.Landmark;
            address.Address.City = Address.City;
            address.Address.State = Address.State;
            address.Address.Country = Address.Country;
            address.Address.PinCode = Address.PinCode;
            address.Address.State = Address.State;
            address.Address.Country = Address.Country;
            return address;
        }

        public void Validate()
        {
            EntityValidator.Validate(this);

            if (IsEmpty())
                throw new ValidationException("Enter address");
        }
    }
}
