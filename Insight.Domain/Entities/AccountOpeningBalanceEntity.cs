using Insight.Domain.Properties;
using System;
using System.ComponentModel.DataAnnotations;

namespace Insight.Domain.Entities
{
    public class AccountOpeningBalanceEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "AccountNameCannotBeEmpty")]
        public string AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsAdjusted { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "CompanyNameCannotBeEmpty")]
        public string CompanyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "PeriodCannotBeEmpty")]
        public string PeriodId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "CompanyPeriodCannotBeEmpty")]
        public string CompanyPeriodId { get; set; }
    }
}
