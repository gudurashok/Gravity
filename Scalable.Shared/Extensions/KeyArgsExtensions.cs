using System.Windows.Forms;

namespace Scalable.Shared.Extensions
{
    public static class KeyEventArgsExtensions
    {
        public static bool IsF5(this KeyEventArgs e)
        {
            return e.KeyCode == Keys.F5 && e.Modifiers == Keys.None;
        }

        public static bool IsF4(this KeyEventArgs e)
        {
            return e.KeyCode == Keys.F4 && e.Modifiers == Keys.None;
        }

        public static bool IsCtrlR(this KeyEventArgs e)
        {
            return e.Control && e.KeyCode == Keys.R && !e.Shift & !e.Alt;
        }
    }
}
