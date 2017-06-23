using Ferry.Win.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;

namespace Ferry.Win.Common
{
    public class FerryApp : ReleaseGravityAppBase
    {
        protected override FMainBase getMainForm()
        {
            return new FMain(this);
        }
    }
}
