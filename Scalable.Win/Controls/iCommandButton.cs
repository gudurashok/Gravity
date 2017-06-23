using System.ComponentModel;
using Scalable.Win.Enums;

namespace Scalable.Win.Controls
{
    public class iCommandButton : iButton
    {
        [DefaultValue(CommandBarAction.Default)]
        public CommandBarAction Action { get; set; }
    }
}
