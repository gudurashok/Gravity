using Gravity.Root.Common;
using Gravity.Root.Forms;
using Gravity.Root.Model;
using Mingle.UC.Forms;
using Mingle.Win.Forms;

namespace Mingle.Win.Common
{
    public class MingleApp : ReleaseGravityAppBase
    {
        protected override FCompanyGroupBase getCompanyGroupForm(CompanyGroup coGroup)
        {
            return new FCompanyGroup(coGroup);
        }

        protected override FMainBase getMainForm()
        {
            return new FMain(this);
        }

        //protected override void insertData()
        //{
        //    base.insertData();
        //    new DefaultDataRepository(GravitySession.CompanyGroup).Insert();

        //    if (AppConfig.CreateTestParties)
        //        new TestPartiesRepository().Insert();
        //}
    }
}
