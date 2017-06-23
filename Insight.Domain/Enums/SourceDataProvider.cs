using System.ComponentModel;

namespace Insight.Domain.Enums
{
    public enum SourceDataProvider
    {
        [Description("None")]
        None = 0,
        [Description("EASY")]
        Easy = 1,
        [Description("MCS")]
        Mcs = 2,
        [Description("TCS")]
        Tcs = 3
    }
}
