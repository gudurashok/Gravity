using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Properties;
using Raven.Imports.Newtonsoft.Json;

namespace Mingle.Domain.Model
{
    public class PersonRelation
    {
        public string PersonId { get; set; }
        public string Relation { get; set; }

        [JsonIgnore]
        private Party _person;
        [JsonIgnore]
        public Party Person
        {
            get { return _person; }
            set
            {
                _person = value;
                PersonId = _person == null ? string.Empty : _person.Entity.Id;
            }
        }

        [JsonIgnore]
        public string Name
        {
            get { return _person.Entity.Name; }
        }

        public void Validate()
        {
            if (Person == null)
                throw new ValidationException(Resources.PartyNameCannotBeEmpty);
        }
    }
}
