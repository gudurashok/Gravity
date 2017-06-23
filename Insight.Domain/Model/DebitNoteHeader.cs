using Insight.Domain.Entities;

namespace Insight.Domain.Model
{
    public class DebitNoteHeader : TransactionHeaderEntity
    {
        public Daybook Daybook { get; set; }
        public Account Account { get; set; }
    }
}
