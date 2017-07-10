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
            var fullNameEntity = new FullName { First = "Rajiv", Middle = "N", Last = "Shah" };

            var contact = PartyEntity.New();
            contact.Type = PartyType.Person;
            contact.Salutation = "Sri.";
            contact.Name = fullNameEntity.ToString();
            contact.FullName = fullNameEntity;
            contact.Gender = Gender.Male;
            contact.Photo = getImage(@"\\SVR-1\\Public\\TestImages\\rajiv.jpg");
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
            fullNameEntity = new FullName { First = "Jigna", Middle = "R", Last = "Shah" };
            var spouse = PartyEntity.New();
            spouse.Type = PartyType.Person;
            spouse.Name = fullNameEntity.ToString();
            spouse.Salutation = "Mrs.";
            spouse.FullName = fullNameEntity;
            spouse.Gender = Gender.Female;
            spouse.Photo = getImage(@"\\SVR-1\\Public\\TestImages\\jigna.jpg");
            session.Store(spouse);

            //create a person with full details
            var person = createTestPersonWithFullDetails(org, spouse, address);
            session.Store(person);
        }

        private Address createTestAddress()
        {
            var address = new Address();
            address.Street = "A-803, Prime Arcade";
            address.Area = "Adajan";
            address.Landmark = "Prime Arcade";
            address.City = "Surat";
            address.State = "Gujarat";
            address.Country = "India";
            address.PinCode = "395009";
            //session.Store(address);
            return address;
        }

        private PartyEntity createTestOrganization(string contactId, Address address)
        {
            var org = PartyEntity.New();
            org.Name = "Gravity Software Technologies";
            org.Type = PartyType.Organization;
            //org.ParentId = 
            org.Salutation = "M/s.";
            //org.Prefix =
            org.ShortName = "Gravity Tech";
            org.AliasName = "Gravity Sfotech";
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
            org.Phones.Add(new Phone { Nr = "+91-7881923456", Label = "Mobile" });
            org.Phones.Add(new Phone { Nr = "+91-9449438821", Label = "3G" });

            //Emails
            org.Emails.Add(new Email { EmailId = "info@gravitysoftware.in", Label = "" });
            org.Emails.Add(new Email { EmailId = "gravitysoftware@live.in", Label = "" });

            //IMs
            org.InstantMessengers.Add(new InstantMessenger { IMName = "Skype", IMId = "gravitysoftware", Label = "" });
            org.InstantMessengers.Add(new InstantMessenger { IMName = "gtalk", IMId = "gravitysoftware.in@gmail.com", Label = "" });

            //Websites
            org.Websites.Add(new Website { Label = "Main site", Url = @"www.gravitysoftware.in" });
            org.Websites.Add(new Website { Label = "Alternate site", Url = @"www.gravitysoftware.ord" });

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
            persons.Add(getPerson(new FullName { First = "Parshwa", Middle = "N", Last = "Shah" }));
            persons.Add(getPerson(new FullName { First = "Komal", Middle = "N", Last = "Shah" }));
            persons.Add(getPerson(new FullName { First = "Krusha", Middle = "N", Last = "Shah" }));
            persons.Add(getPerson(new FullName { First = "Ramesh", Middle = "A", Last = "Shah" }));
            persons.Add(getPerson(new FullName { First = "Sripathi", Middle = "K", Last = "Patel" }));
            persons.Add(getPerson(new FullName { First = "Bhaskar", Middle = "S", Last = "Kapadia" }));
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
            var fullNameEntity = new FullName { First = "Nikhil", Middle = "N", Last = "Shah" };
            var ashok = PartyEntity.New();
            ashok.Type = PartyType.Person;
            ashok.Name = fullNameEntity.ToString();
            ashok.FullName = fullNameEntity;
            ashok.Gender = Gender.Male;
            ashok.Salutation = "Mr.";
            ashok.BloodGroup = BloodGroup.BPositive;
            ashok.Nickname = "Shh!";
            ashok.ShortName = "Ask";
            ashok.AliasName = "lihkiN";
            ashok.Notes = "Nikhil is founder of Gravity Software Technolgies. He is specialized in enterprise accounting and tax consultant in varous business domains.";

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
            ashok.Phones.Add(new Phone { Nr = "+91-9896123444", Label = "Mobile" });
            ashok.Phones.Add(new Phone { Nr = "+91-9449438821", Label = "3G" });

            //Emails
            ashok.Emails.Add(new Email { EmailId = "nikhil.surat@gmail.com", Label = "Alternate" });
            ashok.Emails.Add(new Email { EmailId = "shah.nikhil@gmail.com", Label = "Personal" });
            ashok.Emails.Add(new Email { EmailId = "rajiv.shah@gravitysoftware.in", Label = "Office" });

            //IMs
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "Skype", IMId = "nikhil.shah", Label = "Official" });
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "gtalk", IMId = "shah.nikhil", Label = "Personal" });
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "MSN", IMId = "nikhilshahg@msn.com", Label = "" });
            ashok.InstantMessengers.Add(new InstantMessenger { IMName = "YIM", IMId = "nishahg@yahoo.com", Label = "Personal" });

            //Websites
            ashok.Websites.Add(new Website { Label = "Personal", Url = @"www.nishah.com" });
            ashok.Websites.Add(new Website { Label = "Office", Url = @"www.gravityapps.com" });

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

            //CustomProperties
            ashok.CustomProperties.Add(new CustomProperty { Name = "Qualification", Value = "BCom" });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Vehicles", Value = 3 });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Bikes", Value = 2 });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Cars", Value = 1 });
            ashok.CustomProperties.Add(new CustomProperty { Name = "Car Name", Value = "Figo" });

            ashok.Photo = getImage(@"\\SVR-1\\Public\\TestImages\\cooool.jpg");

            return ashok;
        }

        #endregion
    }
}
