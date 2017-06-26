using System;
using System.Collections.Generic;
using Gravity.Root.Common;
using Mingle.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using Mingle.Domain.Model;
using Mingle.Domain.Properties;

namespace Mingle.Domain.Entities
{
    public class PartyEntity
    {
        public string Id { get; set; }
        public PartyType Type { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "PartyNameCannotBeEmpty")]
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string Salutation { get; set; }
        public string ShortName { get; set; }
        public string AliasName { get; set; }
        public string Abbreviation { get; set; }
        public FullName FullName { get; set; }
        public string Nickname { get; set; }
        public Gender Gender { get; set; }
        public BloodGroup BloodGroup { get; set; }
        public IList<string> Languages { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public IList<PartyContact> Contacts { get; set; }
        public IList<PartyAddress> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Email> Emails { get; set; }
        public IList<InstantMessenger> InstantMessengers { get; set; }
        public IList<Website> Websites { get; set; }
        public IList<PartyDate> Dates { get; set; }
        public IList<string> Professions { get; set; }
        public IList<string> NatureOfContacts { get; set; }
        public IList<PersonRelation> Relations { get; set; }
        public IList<CustomProperty> CustomProperties { get; set; }
        public DateTime CreatedOn { get; private set; }
        public PartyStatus Status { get; set; }

        public PartyEntity()
        {
            FullName = new FullName();
            Languages = new List<string>();
            Contacts = new List<PartyContact>();
            Addresses = new List<PartyAddress>();
            Phones = new List<Phone>();
            Emails = new List<Email>();
            InstantMessengers = new List<InstantMessenger>();
            Websites = new List<Website>();
            Dates = new List<PartyDate>();
            Professions = new List<string>();
            NatureOfContacts = new List<string>(); // Equal to Relations for person
            Relations = new List<PersonRelation>(); // Equal to NatureOfContacts for org
            CustomProperties = new List<CustomProperty>();
            CreatedOn = DateTime.Now;
            Status = PartyStatus.Active;
        }

        public static PartyEntity New()
        {
            return new PartyEntity { Id = EntityPrefix.PartyPrefix };
        }
    }
}
