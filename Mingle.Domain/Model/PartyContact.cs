using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Raven.Imports.Newtonsoft.Json;

namespace Mingle.Domain.Model
{
    public class PartyContact
    {
        public string PartyId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public bool IsPreferred { get; set; }

        [JsonIgnore]
        private Party _party;
        [JsonIgnore]
        public Party Party
        {
            get { return _party; }
            set
            {
                _party = value;
                PartyId = _party == null ? string.Empty : _party.Entity.Id;
            }
        }

        [JsonIgnore]
        public string Name
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return Party.Entity.Name;
        }

        public void Validate()
        {
            if (Party == null)
                throw new ValidationException(Resources.PartyNameCannotBeEmpty);
        }
    }
}
