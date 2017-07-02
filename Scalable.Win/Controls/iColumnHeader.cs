using System.Windows.Forms;
using Scalable.Shared.Enums;

namespace Scalable.Win.Controls
{
    public class iColumnHeader : ColumnHeader
    {
        //public int MinWidth { get; set; }
        //public int MaxWidth { get; set; }
        public bool AutoResizable { get; set; }
        //public string Format { get; set; }
        public DataType DataType { get; set; }

        public iColumnHeader(string name)
            : this(name, name) { }

        public iColumnHeader(string name, string headerText)
            : this(name, headerText, DataType.Text) { }

        public iColumnHeader(string name, DataType dataType, int width)
            : this(name, name, dataType, width) { }

        public iColumnHeader(string name, string headerText, DataType dataType)
            : this(name, headerText, dataType, 25) { }

        public iColumnHeader(string name, string headerText, DataType dataType, int width)
        {
            DataType = dataType;
            Width = width;
            Name = name;
            Text = headerText;
            TextAlign = getTextAlignment();
        }

        public iColumnHeader(string name, bool autoResizable)
            : this(name, name, autoResizable) { }

        public iColumnHeader(string name, bool autoResizable, int defaultWidth)
            : this(name, name, autoResizable)
        {
            Width = defaultWidth;
        }

        public iColumnHeader(string name, string headerText, bool autoResizable)
            : this(name, headerText)
        {
            AutoResizable = autoResizable;
        }

        public iColumnHeader(string name, int width)
            : this(name, name, width) { }

        public iColumnHeader(string name, string headerText, int width)
            : this(name, headerText, false)
        {
            Width = width;
        }

        //TODO: Width should be renamed to minimum width then act accordingly
        //public iColumnHeader(string name, bool autoResizable, int width)
        //    : this(name, autoResizable)
        //{
        //    Width = width;
        //}

        private HorizontalAlignment getTextAlignment()
        {
            return DataType == DataType.Number
                                ? HorizontalAlignment.Right
                                : HorizontalAlignment.Left;
        }
    }
}
