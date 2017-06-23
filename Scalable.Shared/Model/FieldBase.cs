namespace Scalable.Shared.Model
{
    public abstract class FieldBase
    {
        public int Nr { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public object Value { get; set; }
        public object DefaultValue { get; set; }
        public bool Required { get; set; }
        public bool Unique { get; set; }
        public bool Visible { get; set; }
        public bool Enabled { get; set; }
        public bool ReadOnly { get; set; }

        //public DataType Type { get; set; }
        //public object Tag { get; set; }
        //public ControlType ControlType { get; set; } //TODO: coudld be enum...
        //public Control Control { get; set; }
        //TODO: Visual Appearance props... like back, fore colors, font, formating etc. 
        //TODO: 

        protected FieldBase()
        {
            Enabled = true;
            Visible = true;
        }
    }
}
