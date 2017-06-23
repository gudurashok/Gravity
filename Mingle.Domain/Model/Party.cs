using System.Text;
using Gravity.Root.Common;
using Mingle.Domain.Entities;
using Mingle.Domain.Repositories;

namespace Mingle.Domain.Model
{
    public class Party
    {
        private bool isFullDetailsPopulated;

        #region Properties

        public PartyEntity Entity { get; private set; }
        public Party Parent { get; set; }

        #endregion

        #region Constructor

        public Party(PartyEntity entity)
        {
            Entity = entity;
        }

        public static Party New()
        {
            return new Party(PartyEntity.New());
        }

        #endregion

        #region Equals

        public bool Equals(Party party)
        {
            return Entity.Id == party.Entity.Id;
        }

        #endregion

        #region ToString

        public override string ToString()
        {
            return Entity.Name;
        }

        public string ToStringWithSalutation()
        {
            return string.IsNullOrWhiteSpace(Entity.Salutation)
                            ? Entity.Name
                            : string.Format("{0} {1}", Entity.Salutation.Trim(), Entity.Name);
        }

        #endregion

        public bool IsNew()
        {
            return Entity.Id == EntityPrefix.PartyPrefix;
        }

        public void PopulateFullDetails()
        {
            if (isFullDetailsPopulated)
                return;

            isFullDetailsPopulated = true;
            new PartyRepository().FillPartyFullDetails(this);
        }

        public string ToStringAllReferencedContacts()
        {
            var contactInfo = new StringBuilder();
            var repo = new PartyRepository();
            foreach (var contact in repo.GetAllRefferedContacts(Entity.Id))
                contactInfo.Append(contact.Name).Append(", ");

            return removeTrailingComma(contactInfo.ToString());
        }

        public string ToStringContacts()
        {
            var contactInfo = new StringBuilder();

            foreach (var contact in Entity.Contacts)
                contactInfo.Append(contact.ToString()).Append(", ");

            return removeTrailingComma(contactInfo.ToString());
        }

        public string ToStringPhoneNumbers()
        {
            var phones = new StringBuilder();

            foreach (var phone in Entity.Phones)
                phones.Append(phone.ToStringWithLabel()).Append(", ");

            return removeTrailingComma(phones.ToString());
        }

        public string ToStringLocation()
        {
            return Entity.Addresses.Count > 0
                       ? Entity.Addresses[0].ToStringAreaAndCity()
                       : string.Empty;
        }

        public string ToStringAddresss()
        {
            return Entity.Addresses.Count > 0
                    ? Entity.Addresses[0].ToString()
                    : string.Empty;
        }

        public string ToStringAddresssWithLabels()
        {
            return Entity.Addresses.Count > 0
                    ? Entity.Addresses[0].ToStringWithLabels()
                    : string.Empty;
        }

        public string ToStringNatureOfContacts()
        {
            var natureOfContacts = new StringBuilder();

            foreach (var nature in Entity.NatureOfContacts)
                natureOfContacts.Append(nature).Append(", ");

            return removeTrailingComma(natureOfContacts.ToString());
        }

        public string ToStringEmailIds()
        {
            var emails = new StringBuilder();

            foreach (var email in Entity.Emails)
                emails.Append(email.ToStringWithLabel()).Append(", ");

            return removeTrailingComma(emails.ToString());
        }

        public string ToStringIMIds()
        {
            var imIds = new StringBuilder();

            foreach (var imId in Entity.InstantMessengers)
                imIds.Append(imId.ToStringWithLabel()).Append(", ");

            return removeTrailingComma(imIds.ToString());
        }

        private static string removeTrailingComma(string value)
        {
            return value.Length > 2 ? value.Remove(value.Length - 2, 2) : value;
        }
    }
}
