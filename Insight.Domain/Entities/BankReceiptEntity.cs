using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class BankReceiptEntity : TransactionHeaderEntity
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ChequeNrCannotBeEmpty")]
        public string ChequeNr { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "BankDetailsCannotBeEmpty")]
        public string BankBranchName { get; set; }
        public bool IsRealised { get; set; }
    }
}
