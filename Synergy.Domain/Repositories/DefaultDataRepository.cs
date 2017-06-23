using Gravity.Root.Repositories;
using Raven.Client;
using Synergy.Domain.Model;

namespace Synergy.Domain.Repositories
{
    public class DefaultDataRepository : RepositoryBase
    {
        #region Declarations

        private IDocumentSession _session;

        #endregion

        #region Public Method

        public void Insert()
        {
            using (_session = Store.OpenSession())
            {
                if (SysConfig.DefaultDataInserted)
                    return;

                createAll();
                _session.SaveChanges();
                SysConfig.DefaultDataInserted = true;
            }
        }

        private void createAll()
        {
            //createTaskTypes();
            //createLocations();
            //createProjects();
            //createChecklists();
        }

        #endregion
    }
}
