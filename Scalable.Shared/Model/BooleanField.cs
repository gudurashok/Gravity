namespace Scalable.Shared.Model
{
    public class BooleanField : FieldBase
    {
        public bool GetValue()
        {
            return Value != null && (bool)Value;
        }
    }
}
