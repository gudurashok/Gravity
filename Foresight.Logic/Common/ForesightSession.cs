using Foresight.Logic.DataAccess;
using Gravity.Root.Model;

namespace Foresight.Logic.Common
{
    public static class ForesightSession
    {
        public static CompanyGroup CompanyGroup { get; set; }
        public static DataContext Dbc { get; private set; }

        public static void OpenCompanyGroup(CompanyGroup group)
        {
            CompanyGroup = group;
            Dbc = new DataContext(group);
        }
    }
}
