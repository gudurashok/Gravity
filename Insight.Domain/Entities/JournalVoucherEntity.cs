using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class JournalVoucherEntity : TransactionHeaderEntity
    {
        public int TxnType { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "AccountToCreditCannotBeEmpty")]
        public string CreditAccountId { get; set; }
        public string NotesCredit { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "AccountToDebitCannotBeEmpty")]
        public string DebitAccountId { get; set; }
        public string NotesDebit { get; set; }
    }
}
