using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Scalable.Win.Controls
{
    public class iMenuStrip : MenuStrip
    {
        public void HighlightMenuItem(ToolStripItem item)
        {
            resetMenuItemColors();
            item.BackColor = Color.Black;
            item.ForeColor = Color.White;
        }

        private void resetMenuItemColors()
        {
            foreach (var it in Items.Cast<ToolStripItem>())
            {
                it.ResetBackColor();
                it.ResetForeColor();
            }
        }
    }
}
