using Insight.Domain.Entities;

namespace Ferry.Logic.Model
{
    public class ForesightChartOfAccount
    {
        public ChartOfAccountEntity Entity { get; set; }
        public int ForesightId { get; set; }
        public int ParentForesightId { get; set; }
    }
}
