using Foresight.Win.Forms;
using Gravity.Root.Common;
using Gravity.Root.Forms;

namespace Foresight.Win.Common
{
    public class ForesightApp : ReleaseGravityAppBase
    {
        protected override void setMainForm()
        {
            MainForm = new FMain();
        }
    }
}
