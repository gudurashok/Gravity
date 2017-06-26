using System.ComponentModel.DataAnnotations;
using Insight.Domain.Enums;
using Insight.Domain.Properties;

namespace Insight.Domain.Entities
{
    public class CompanyPeriodEntity
    {
        public string Id { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "CompanyCannotBeEmpty")]
        public string CompanyId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), 
            ErrorMessageResourceName = "PeriodCannotBeEmpty")]
        public string PeriodId { get; set; }
        public SourceDataProvider SourceDataProvider { get; set; }
        public string SourceDataPath { get; set; }
        public bool IsImported { get; set; }
        public int ForesighId { get; set; }

        public CompanyPeriodEntity()
        {
            SourceDataProvider = SourceDataProvider.Insight;
        }
    }
}
