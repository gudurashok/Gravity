using Mingle.Domain.Entities;
using Gravity.Root.Repositories;
using Raven.Client;
using Gravity.Root.Model;
using Mingle.Domain.Model;

namespace Mingle.Domain.Repositories
{
    public class DefaultDataRepository : RepositoryBase
    {
        #region Declarations

        private IDocumentSession _session;
        private readonly CompanyGroup _coGroup;

        #endregion

        #region Constructor

        public DefaultDataRepository(CompanyGroup coGroup)
        {
            _coGroup = coGroup;
        }

        #endregion

        #region Public Method

        public void Insert()
        {
            using (_session = Store.OpenSession())
            {
                if (SysConfig.DefaultDataInserted)
                    return;

                _session.SaveChanges();
                SysConfig.DefaultDataInserted = true;
                SysConfig.CoGroupPartyId = insertCoGroupParty().Id;
            }
        }

        #endregion

        #region CoGroup Self Party

        private PartyEntity insertCoGroupParty()
        {
            var repo = new PartyRepository();
            var partyEntity = PartyEntity.New();
            partyEntity.Name = _coGroup.Entity.Name;
            partyEntity.Salutation = "M/s.";

            partyEntity.Addresses.Add(new PartyAddress
            {
                //TODO: can come from app.config
                Address = new Address
                {
                    Street = "(Please enter your street/house/door/plot number/name here)",
                    Area = "Please enter your area name here",
                    City = "SURAT",
                    State = "Gujarat",
                    Country = "India"
                },
                Label = "Office",
                UsageLabel = "Correspondence"
            });

            repo.Save(new Party(partyEntity));
            return partyEntity;
        }

        #endregion
    }
}
