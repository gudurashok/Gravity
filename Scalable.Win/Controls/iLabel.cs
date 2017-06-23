using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Scalable.Win.Controls
{
    public class iLabel : Label
    {
        private Size _currentSize;

        private bool _autoSizeLeft;

        [DefaultValue(false)]
        public bool AutoSizeLeft
        {
            get { return _autoSizeLeft; }
            set
            {
                _currentSize = Size;
                _autoSizeLeft = value;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (AutoSize && AutoSizeLeft)
            {
                Location = new Point(Location.X - (Size.Width - _currentSize.Width), Location.Y);
                _currentSize = Size;
            }

            base.OnSizeChanged(e);
        }
    }
}
