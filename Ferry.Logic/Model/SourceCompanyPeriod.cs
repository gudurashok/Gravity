using Scalable.Shared.Model;

namespace Ferry.Logic.Model
{
    public class SourceCompanyPeriod
    {
        public string Id { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public DatePeriod Period { get; set; }
        public string SourceDataPath { get; set; }

        public bool IsNew()
        {
            return string.IsNullOrWhiteSpace(Id);
        }
    }
}
