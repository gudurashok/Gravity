using System.Windows.Forms;
using System.Drawing;

namespace Scalable.Win.Common
{
    public static class ListViewItemColorProcessor
    {
        public static void Invert(ListView lvw, int count)
        {
            var swap = false;
            var i = 1;

            foreach (ListViewItem lvi in lvw.Items)
            {
                lvi.UseItemStyleForSubItems = true;
                if (swap)
                    lvi.BackColor = Color.PowderBlue;

                if (i < count)
                    i++;
                else
                {
                    i = 1;
                    swap = !swap;
                }
            }
        }
    }
}
