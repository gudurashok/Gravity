using System;
using System.Windows.Forms;

namespace Scalable.Win.Controls
{
    public class iDateTimePicker : DateTimePicker
    {
        public event EventHandler CheckedChanged;

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
                OnCheckedChanged();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.X >= 2 && e.X <= 17 && e.Y >= 2 && e.Y <= 17)
                OnCheckedChanged();
        }

        protected virtual void OnCheckedChanged()
        {
            if (CheckedChanged != null)
                CheckedChanged(this, EventArgs.Empty);
        }
    }
}
