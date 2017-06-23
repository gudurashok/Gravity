using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Mingle.Domain.Entities;
using Mingle.Domain.Model;
using Mingle.Domain.Enums;
using Gravity.Root.Repositories;
using Raven.Client;

namespace Mingle.Domain.Repositories
{
    public class TestPartiesRepository : RepositoryBase
    {
        #region Declarations

        private IDocumentSession session;

        #endregion

        #region Public Method

        public void Insert()
        {
            using (session = Store.OpenSession())
            {
                if (SysConfig.TestDataInserted)
                    return;

                createRefernceLists();
                createInternal();
                session.SaveChanges();
                SysConfig.TestDataInserted = true;
            }
        }

        private void createRefernceLists()
        {

        }

        #endregion

        #region Test Data Creation

        private void createInternal()
        {
            //create a contact person for org
            var fullNameEntity = new FullName { First = "Srikanth", Middle = "M", Last = "Guduru" };

            var contact = PartyEntity.New();
            contact.Type = PartyType.Person;
            contact.Salutation = "Chi.";
            contact.Name = fullNameEntity.ToString();
            contact.FullName = fullNameEntity;
            contact.Gender = Gender.Male;
            contact.Photo = getImage(@"\\SVR-1\\Public\\TestImages\\srikanth.jpg");
            session.Store(contact);
            session.SaveChanges();

            //create org
            var address = createTestAddress();
            var org = createTestOrganization(contact.Id, address);
            session.Store(org);

            //create few more persons with min. details
            var persons = createTestPersonsWithMinDeatils().GetEnumerator();
            while (persons.MoveNext())
                session.Store(persons.Current);

            //create a person for spouse relation
            fullNameEntity = new FullName { First = "Sridevi", Middle = "A", Last = "Guduru" };
            var spouse = PartyEntity.New();
            spouse.Type = PartyType.Person;
            spouse.Name = fullNameEntity.ToString();
            spouse.Salutation = "Mrs.";
            spouse.FullName = fullNameEntity;
            spouse.Gender = Gender.Female;
            spouse.Photo = getImage(@"\\SVR-1\\Public\\TestImages\\sridevi.jpg");
            session.Store(spouse);

            //create a person with full details
            var person = createTestPersonWithFullDetails(org, spouse, address);
            session.Store(person);
        }

        private Address createTestAddress()
        {
            var address = new Address();
            address.Street = "12-1-106/1, Plot #89, Road #1\nAjay Nagar Colony (New), Bandlaguda";
            address.Area = "Nagole";
            address.Landmark = "Graveyard";
            address.City = "Hyderabad";
            address.State = "Andhra Pradesh";
            address.Country = "India";
            address.PinCode = "500068";
            //session.Store(address);
            return address;
        }

        private PartyEntity createTestOrganization(string contactId, Address address)
        {
            var org = PartyEntity.New();
            org.Name = "Gravity Software Technologies Pvt. Ltd.";
            org.Type = PartyType.Organization;
            //org.ParentId = 
            org.Salutation = "M/s.";
            //org.Prefix =
            org.ShortName = "iScalable";
            org.AliasName = "Scalable Apps";
            org.Abbreviation = "S3PL";
            //org.Suffix =
            //org.Nickname =
            org.Notes = "Gravity Software Technologies is specialized in enterprise software development company.";
            //Contacts
            org.Contacts.Add(new PartyContact { PartyId = contactId, Designation = "Developer", Department = "Development", IsActive = true });

            //Temporary Aadrress... 
            //Permanent Addresses
            var addr = new PartyAddress
            {
                Address = address,
                Label = "Office",
                UsageLabel = "Billing",
                IsActive = true,
                IsPreferred = true
            };

            org.Addresses.Add(addr);

            //Phones
            org.Phones.Add(new Phone { Nr = "+91-9989923219", Label = "Mobile" });
            org.Phones.Add(new Phone { Nr = "+91-9449438821", Label = "3G" });

            //Emails
            org.Emails.Add(new Email { EmailId = "info@iscalable.com", Label = "" });
            org.Emails.Add(new Email { EmailId = "iscalable@live.in", Label = "" });

            //IMs
            org.InstantMessengers.Add(new InstantMessenger { IMName = "Skype", IMId = "iscalable", Label = "" });
            org.InstantMessengers.Add(new InstantMessenger { IMName = "gtalk", IMId = "iscalable@gmail.com", Label = "" });

            //Websites
            org.Websites.Add(new Website { Label = "Main site", Url = @"www.iscalable.com" });
            org.Websites.Add(new Website { Label = "Alternate site", Url = @"www.scalableapps.com" });

            //Dates
            org.Dates.Add(new PartyDate { Label = "Anniversary", Value = new DateTime(2011, 2, 28) });

            //Professions/Business
            org.Professions.Add("Software");

            //Natures of Contacts
            org.NatureOfContacts.Add("Owner");

            //Relations for persons
            //org.Relations.Add(new Relation());

            //CustomProperties
            org.CustomProperties.Add(new CustomProperty { Name = "Development Platform", Value = "Micrcosoft .NET" });
            org.CustomProperties.Add(new CustomProperty { Name = "Operating System", Value = "MS Windows" });
            org.CustomProperties.Add(new CustomProperty { Name = "Employees", Value = 3 });

            org.Photo = getImage(@"\\SVR-1\\Public\\TestImages\\s3pl.jpg");

            return org;
        }

        private static byte[] getImage(string path)
        {
            if (!File.Exists(path))
                return null;

            return (byte[])(new ImageConverter().ConvertTo(new Bitmap(path), typeof(byte[])));
        }

        private IEnumerable<PartyEntity> createTestPersonsWithMinDeatils()
        {
            var persons = new List<PartyEntity>();
            persons.Add(getPerson(new FullName { First = "Balaji", Middle = "H", Last = "Guduru" }));
            persons.Add(getPerson(new FullName { First = "Siddhartha", Middle = "A", Last = "Guduru" }));
            persons.Add(getPerson(new FullName { First = "Markandeya", Middle = "H", Last = "Guduru" }));
            persons.Add(getPerson(new FullName { First = "Tejas", Middle = "A", Last = "Guduru" }));
            persons.Add(getPerson(new FullName { First = "Sripathi", Middle = "K", Last = "Dasari" }));
            persons.Add(getPerson(new FullName { First = "Bhaskar", Middle = "S", Last = "Kurapati" }));
            return persons;
        }

        private PartyEntity getPerson(FullName fullName)
        {
            var person = PartyEntity.New();
            person.Type = PartyType.Person;
            person.Salutation = "";
            person.Name = fullName.ToString();
            person.FullName = fullName;
            person.Gender = Gender.Male;
            person.Photo = getImage(string.Format(@"\\SVR-1\\Public\\TestImages\\{0}.jpg", fullName.First));
            return person;
        }

        private PartyEntity createTestPersonWithFullDetails(PartyEntity org, PartyEntity spouse, Address address)
        {
            //Basic Details
            //ashok.Id = "Person/1"; // Auto
            var fullNameEntity = new FullName { First = "Ashok", Middle = "H", Last = "Guduru" };
            var ashok = PartyEntity.New();
            ashok.Type = PartyType.Person;
            ashok.Name = fullNameEntity.ToString();
            ashok.FullName = fullNameEntity;
            ashok.Gender = Gender.Male;
            ashok.Salutation = "Mr.";
            ashok.BloodGroup = BloodGroup.BPositive;
            ashok.Nickname = "Shh!";
            ashok.ShortName = "Ask";
            ashok.AliasName = "kohsA";
            ashok.Notes = "Ashok is founder of Scalable Software Solutions Pvt. Ltd. He is specialized in enterprise software development in varous business domains and uses Microsoft family of application development platform such as .NET";

            ////Contacts
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Developer", Department = "Development", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Sr.Developer", Department = "Development", IsActive = false });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Accountant", Department = "Accounts", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Development Manager", Department = "Administration", IsActive = false });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "V.P Sales", Department = "Sales", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "System Architect", Department = "Development", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Business Analyst", Department = "Finance", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Testing Engineer", Department = "Testing", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Finance Adviser", Department = "Finance", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Training Adviser", Department = "Training", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Market Analyst", Department = "Marketing", IsActive = true });
            //ashok.Contacts.Add(new PartyContact { PartyId = org.Id, Designation = "Support Team", Department = "Support", IsActive = true });

            //Addresses
            var paddr = new PartyAddress
            {
                Address = address,
                Label = "Home",
                UsageLabel = "Correspondence",
                IsActive = true,
                IsPreferred = true
            };

            ashok.Addresses.Add(paddr);

            //Phones
            ashok.Phones.Add(new Phone { Nr = "+91-9989923219", Label = "Mobile" });
            ashok.Phones.Add(new Phone { Nr = "+91-9449438821", Label = "3G" });

            //Emails
            ashok.Emails.Add(new Email { EmailId = "ashok.gudur@gmail.com", Label = "Alternate" });
            ashok.Emails.Add(new Email { EmailId = "gudur.ashok@gmail.com", Label = "Personal" });
            ashok.Emails.Add(new Email { EmailId = "ashok@iscalable.com", Label = "Office" });

            //IMs
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "Skype", IMId = "ashok.gudur", Label = "Official" });
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "gtalk", IMId = "ashok.gudur", Label = "Personal" });
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "MSN", IMId = "ashokg@msn.com", Label = "" });
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "YIM", IMId = "ashokg@yahoo.com", Label = "Personal" });

            //Websites
            ashok.Websites.Add(new Website { Label = "Personal", Url = @"www.ashokg.com" });
            ashok.Websites.Add(new Website { Label = "Office", Url = @"www.scalableapps.com" });

            //Dates
            ashok.Dates.Add(new PartyDate { Label = "BirthDay", Value = new DateTime(1971, 1, 2) });
            ashok.Dates.Add(new PartyDate { Label = "MarriageDay", Value = new DateTime(1991, 5, 20) });

            //Professions
            ashok.Professions.Add("Software Development");
            ashok.Professions.Add("Software Consulting");
            ashok.Professions.Add("Accouting and Tax Consulting");
            ashok.Professions.Add("Chartered Accoutants");
            ashok.Professions.Add("Financial Advisor");
            ashok.Professions.Add("Electronic Servicing");
            ashok.Professions.Add("Legal Consultancy");
            ashok.Professions.Add("Manufacturing of Rice");
            ashok.Professions.Add("Mobile Repairing");
            ashok.Professions.Add("Auto Garage");

            //Natures of Contacts
            ashok.NatureOfContacts.Add("Supplier");
            ashok.NatureOfContacts.Add("Owner");
            ashok.NatureOfContacts.Add("Software Consultant");
            ashok.NatureOfContacts.Add("Customer");
            ashok.NatureOfContacts.Add("Employee");
            ashok.NatureOfContacts.Add("Legal Consultant");
            ashok.NatureOfContacts.Add("Financial Advisor");
            ashok.NatureOfContacts.Add("Tax Consultant");
            ashok.NatureOfContacts.Add("Plumber");
            ashok.NatureOfContacts.Add("Electrician");


            //Relations
            ashok.Relations.Add(new PersonRelation { Relation = "Wife", PersonId = spouse.Id });

            ashok.Languages.Add("English");
            ashok.Languages.Add("Hindi");
            ashok.Languages.Add("Gujarati");
            ashok.Languages.Add("Telugu");

            //CustomProperties
            ashok.CustomProperties.Add(new CustomProperty { Name = "Qualification", Value = "BCA" });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Vehicles", Value = 3 });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Bikes", Value = 2 });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Cars", Value = 1 });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Car Name", Value = "Alto" });

            ashok.Photo = getImage(@"\\SVR-1\\Public\\TestImages\\ashok.jpg");

            return ashok;
        }

        #endregion
    }
}
