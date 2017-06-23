using Mingle.Domain.Model;

namespace Mingle.Domain.ViewModel
{
    public class PartyListItem
    {
        public Party Party { get; set; }

        public string Name
        {
            get { return Party.Entity.Name; }
        }

        public string Contact
        {
            get { return Party.ToStringContacts(); }
        }

        public string Phone
        {
            get { return Party.ToStringPhoneNumbers(); }
        }

        public string Location
        {
            get { return Party.ToStringLocation(); }
        }
    }
}
