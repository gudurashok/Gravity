using Ferry.Win.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;

namespace Ferry.Win.Common
{
    public class TestCoGroupFerryApp : TestCoGroupGravityAppBase
    {
        //protected override void insertData()
        //{
        //    base.insertData();
        //    new DefaultDataRepository(GravitySession.CompanyGroup).Insert();

        //    if (AppConfig.CreateTestParties)
        //        new TestPartiesRepository().Insert();
        //}

        protected override FMainBase getMainForm()
        {
            return new FMain(this);
        }
    }
}
