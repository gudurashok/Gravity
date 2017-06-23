using System.Windows.Forms;
using Scalable.Shared.Enums;

namespace Scalable.Shared.Common
{
    public static class AmountFormat
    {
        public static decimal Value(AmountFormatStyle format)
        {
            if (format == AmountFormatStyle.Crores) return 10000000;
            if (format == AmountFormatStyle.Lacs) return 100000;
            if (format == AmountFormatStyle.Thousands) return 1000;
            return 1;
        }

        public static decimal Value(ListControl control)
        {
            return Value((AmountFormatStyle)(control.SelectedValue));
        }
    }
}
