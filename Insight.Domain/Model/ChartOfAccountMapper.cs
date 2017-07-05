using Insight.Domain.Enums;

namespace Insight.Domain.Model
{
    public class ChartOfAccountMapper
    {
        public string Id { get; set; }
        public string ChartOfAccountId { get; set; }
        public string ChartOfAccountName { get; set; }
        public AccountTypes Type { get; set; }
        public string EasyCode { get; set; }
        public string McsCode { get; set; }
        public string TcsCode { get; set; }
    }
}
