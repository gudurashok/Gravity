namespace Insight.Domain.Model
{
    public class DebitNoteLine : LineItem
    {
        public string NoteId { get; set; }
        public decimal Price { get; set; }
    }
}
