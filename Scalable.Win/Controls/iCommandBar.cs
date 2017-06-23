using Scalable.Win.Enums;

namespace Scalable.Win.Controls
{
    public class iCommandBar : iPanel
    {
        public CommandBarActionWrapper this[object sender]
        {
            get { return new CommandBarActionWrapper(((iCommandButton)sender).Action); }
        }
    }
}
