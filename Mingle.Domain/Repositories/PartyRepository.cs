using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Mingle.Domain.Entities;
using Mingle.Domain.Enums;
using Mingle.Domain.Model;
using Scalable.Shared.Common;
using Gravity.Root.Repositories;
using Raven.Client;
using Raven.Client.Linq;
using Mingle.Domain.Properties;

namespace Mingle.Domain.Repositories
{
    public class PartyRepository : RepositoryBase
    {
        //public IEnumerable<PartyListItem> GetPartyListItems()
        //{
        //    return GetAllParties()
        //        .Select(party => new PartyListItem { Party = party })
        //        .OrderBy(p => p.Name)
        //        .ThenBy(p => p.Location)
        //        .ToList();
        //}

        //public IEnumerable<Party> GetAllParties()
        //{
        //    using (var s = Store.OpenSession())
        //    {
        //        return GetAllPartyEntities()
        //            .Select(entity => GetPartyWithFullDetails(entity, s))
        //            .ToList();
        //    }
        //}

        //public IEnumerable<PartyEntity> GetAllPartyEntities()
        //{
        //    using (var s = Store.OpenSession())
        //    {
        //        return s.Query<PartyEntity>();

        //        //return s.Include<PartyEntity>(x => x.ParentId).Load().Select(entity => new Party(entity));

        //        //var q = from u in parties orderby u.Name select u;
        //        //return q.ToList();

        //        //using index...
        //        //return s.Query<Party, Party_AllParties>().ToList();
        //    }
        //}

        public IList<ReferenceListEntity> GetAllReferenceLists()
        {
            using (var s = Store.OpenSession())
                return s.Query<ReferenceListEntity>().ToList();
        }

        public override void DeleteById(string id)
        {
            checkIsCoGroupParty(id);
            checkIsPartyInUseByOtherParty(id);
            base.DeleteById(id);
        }

        private void checkIsCoGroupParty(string id)
        {
            if (id == SysConfig.CoGroupPartyId)
                throw new ValidationException(Resources.CannotDeleteCompanyGroupParty);
        }

        private void checkIsPartyInUseByOtherParty(string id)
        {
            using (var s = Store.OpenSession())
            {
                var party = s.Query<PartyEntity>().Where(p => p.ParentId == id).SingleOrDefault();
                if (party != null)
                    throw new ValidationException(string.Format("This party is in use by another party's parent/group.\nParty name: {0}", party.Name));

                party = s.Query<PartyEntity>().Where(p => p.Contacts.Any(pc => pc.PartyId == id)).FirstOrDefault();
                if (party != null)
                    throw new ValidationException(string.Format("This party is in use by another party's contact. \nParty name: {0}", party.Name));

                party = s.Query<PartyEntity>().Where(p => p.Relations.Any(pr => pr.PersonId == id)).FirstOrDefault();
                if (party != null)
                    throw new ValidationException(string.Format("This party is in use by another party's relation.\nParty name: {0}", party.Name));
            }
        }

        public string GetArea(string nameStartsWith)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<PartyEntity>()
                    .Where(p => p.Addresses.Any(a => a.Address.Area.StartsWith(nameStartsWith)))
                    .FirstOrDefault();

                if (result != null)
                    return result.Addresses[0].Address.Area;

                return null;
            }
        }

        public string GetLandmark(string nameStartsWith)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<PartyEntity>()
                    .Where(p => p.Addresses.Any(a => a.Address.Landmark.StartsWith(nameStartsWith)))
                    .FirstOrDefault();

                if (result != null)
                    return result.Addresses[0].Address.Landmark;

                return null;
            }
        }

        public string GetCity(string nameStartsWith)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<PartyEntity>()
                    .Where(p => p.Addresses.Any(a => a.Address.City.StartsWith(nameStartsWith)))
                    .FirstOrDefault();

                if (result != null)
                    return result.Addresses[0].Address.City;

                return null;
            }
        }

        public override string Save(dynamic entity)
        {
            var party = (Party)entity;
            EntityValidator.Validate(party.Entity);
            checkIfContactsContainsItself(party);
            updateReferenceLists(party.Entity);
            return base.Save(party.Entity);
        }

        private void updateReferenceLists(PartyEntity entity)
        {
            updateList(ListType.AddressTypes, entity.Addresses.Select(a => a.Label));
            updateList(ListType.AddressUsageTypes, entity.Addresses.Select(a => a.UsageLabel));
            updateList(ListType.Countries, entity.Addresses.Select(a => a.Address.Country));
            updateList(ListType.CustomTypes, entity.CustomProperties.Select(c => c.Name));
            updateList(ListType.DateTypes, entity.Dates.Select(d => d.Label));
            updateList(ListType.Departments, entity.Contacts.Select(d => d.Department));
            updateList(ListType.Designations, entity.Contacts.Select(d => d.Designation));
            updateList(ListType.EmailTypes, entity.Emails.Select(e => e.Label));
            updateList(ListType.IMTitleTypes, entity.InstantMessengers.Select(i => i.Label));
            updateList(ListType.IMTypes, entity.InstantMessengers.Select(i => i.IMName));
            updateList(ListType.Languages, entity.Languages);
            updateList(ListType.NatureOfContacts, entity.NatureOfContacts);
            updateList(ListType.PhoneTypes, entity.Phones.Select(p => p.Label));
            updateList(ListType.Professions, entity.Professions);
            updateList(ListType.RelationTypes, entity.Relations.Select(r => r.Relation));
            updateList(ListType.Salutations, new[] { entity.Salutation });
            updateList(ListType.States, entity.Addresses.Select(a => a.Address.State));
            updateList(ListType.WebsiteTypes, entity.Websites.Select(w => w.Label));

            ReferenceList.SaveLists();
        }

        private static void updateList(ListType type, IEnumerable<string> list)
        {
            var refList = ReferenceList.GetList(type);
            var comparer = refList.Select(i => i.ToLower());
            foreach (var item in list.Where(i => !comparer.Contains(i.ToLower())))
                refList.Add(item);
        }

        private void checkIfContactsContainsItself(Party party)
        {
            if (party.Entity.Contacts.Any(pc => pc.PartyId == party.Entity.Id))
                throw new ValidationException(Resources.CannnotSetPartyItselfAsContact);
        }

        public IEnumerable<PartyEntity> GetAllRefferedContacts(string partyId)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<PartyEntity>()
                    .Where(p => p.Contacts.Any(pc => pc.PartyId == partyId))
                    .ToList();
            }
        }

        public Party GetById(string id, bool populateFullDetails, bool throwExceptionIfNotFound = false)
        {
            var entity = Read<PartyEntity>(id, throwExceptionIfNotFound);
            if (entity == null)
                return null;

            return populateFullDetails ? getPartyWithFullDetails(entity) : new Party(entity);
        }

        private Party getPartyWithFullDetails(PartyEntity entity)
        {
            using (var s = Store.OpenSession())
            {
                var party = new Party(entity);
                fillPartyFullDetails(party, s);
                return party;
            }
        }

        public void FillPartyFullDetails(Party party)
        {
            using (var s = Store.OpenSession())
                fillPartyFullDetails(party, s);
        }

        public static Party GetPartyWithPartialDetails(PartyEntity entity, IDocumentSession s)
        {
            var party = new Party(entity);
            fillPartyPartialDetails(party, s);
            return party;
        }

        private static void fillPartyPartialDetails(Party party, IDocumentSession s)
        {
            var entity = party.Entity;
            party.Entity.FullName = entity.FullName;
            party.Entity.Contacts = entity.Contacts.Select(c => getFilledContact(c, s)).ToList();
        }

        private static void fillPartyFullDetails(Party party, IDocumentSession s)
        {
            var entity = party.Entity;
            party.Parent = string.IsNullOrWhiteSpace(entity.ParentId) ? null : new Party(s.Load<PartyEntity>(entity.ParentId));
            party.Entity.FullName = entity.FullName;
            party.Entity.Contacts = entity.Contacts.Select(c => getFilledContact(c, s)).ToList();
            party.Entity.Relations = entity.Relations.Select(r => getFilledRelation(r, s)).ToList();
        }

        private static PersonRelation getFilledRelation(PersonRelation relation, IDocumentSession s)
        {
            relation.Person = new Party(s.Load<PartyEntity>(relation.PersonId));
            return relation;
        }

        private static PartyContact getFilledContact(PartyContact contact, IDocumentSession s)
        {
            contact.Party = new Party(s.Load<PartyEntity>(contact.PartyId));
            return contact;
        }

        public IList<AppMenuItemEntity> GetAllAppMenuItems()
        {
            var menuItems = new List<AppMenuItemEntity>();

            var menuItem = new AppMenuItemEntity();
            menuItem.Nr = 1;
            menuItem.DisplayOrder = "2";
            menuItem.Name = "Users";
            menuItem.Caption = "&Users";
            menuItem.UIControlName = "UUsers";
            menuItem.UIControlPath = "Gravity.Root.Controls";
            menuItem.UIAssembly = "Gravity.Root.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.U;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuItem.IsForAdminOnly = false;
            menuItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 2;
            menuItem.DisplayOrder = "1";
            menuItem.Name = "Parties";
            menuItem.Caption = "&Parties";
            menuItem.UIControlName = "UParties";
            menuItem.UIControlPath = "Mingle.UC.Controls";
            menuItem.UIAssembly = "Mingle.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.P;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuItem.IsForAdminOnly = false;
            menuItems.Add(menuItem);

            if (GravitySession.User.Entity.IsAdmin)
                return menuItems.OrderBy(m => m.DisplayOrder).ToList();

            return menuItems.Where(m => !m.IsForAdminOnly).OrderBy(m => m.DisplayOrder).ToList();
        }

        public void SaveLists(ReferenceListEntity list)
        {
            base.Save(list);
        }
    }
}
