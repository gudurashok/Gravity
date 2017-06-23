using System;
using System.ComponentModel.DataAnnotations;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public abstract class TransactionHeaderEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "DaybookNameCannotBeEmpty")]
        public string DaybookId { get; set; }
        public string DocumentNr { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "AccountNameCannotBeEmpty")]
        public string AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; }
        public string BrokerId { get; set; }
        public bool IsAdjusted { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CompanyNameCannotBeEmpty")]
        public string CompanyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PeriodCannotBeEmpty")]
        public string PeriodId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "CompanyPeriodCannotBeEmpty")]
        public string CompanyPeriodId { get; set; }
    }
}
