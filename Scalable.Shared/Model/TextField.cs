using Scalable.Shared.Enums;

namespace Scalable.Shared.Model
{
    public class TextField : FieldBase
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public TextCaseStyle TextCasing { get; set; }
        public bool Multiline { get; set; }
        public string InputFilterExpr { get; set; }

        public string GetDefaultValue()
        {
            return Value == null ? null : DefaultValue.ToString();
        }

        public string GetValue()
        {
            return Value == null ? null : Value.ToString();
        }
    }
}
