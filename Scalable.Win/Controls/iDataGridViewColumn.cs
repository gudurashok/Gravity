using System.Windows.Forms;

namespace Scalable.Win.Controls
{
    public class iDataGridViewColumn : DataGridViewColumn
    {
                //public int MinWidth { get; set; }
        //public int MaxWidth { get; set; }
        public bool AutoResizable { get; set; }
        //public string Format { get; set; }

        public iDataGridViewColumn(string name)
            : this(name, name) { }

        public iDataGridViewColumn(string name, string headerText)
        {
            Name = name;
            HeaderText = headerText;
        }

        public iDataGridViewColumn(string name, bool autoResizable)
            : this(name, name, autoResizable) { }

        public iDataGridViewColumn(string name, bool autoResizable, int defaultWidth)
            : this(name, name, autoResizable)
        {
            Width = defaultWidth;
        }

        public iDataGridViewColumn(string name, string headerText, bool autoResizable)
            : this(name, headerText)
        {
            AutoResizable = autoResizable;
        }

        public iDataGridViewColumn(string name, int width)
            : this(name, name, width) { }

        public iDataGridViewColumn(string name, string headerText, int width)
            : this(name, headerText, false)
        {
            Width = width;
        }
    }
}
