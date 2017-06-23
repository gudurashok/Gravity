namespace Scalable.Win.Events
{
    public class PicklistSearchResult
    {
        public string Text { get; private set; }
        public object Value { get; private set; }

        public PicklistSearchResult(string text, object value)
        {
            Text = text;
            Value = value;
        }
    }
}
