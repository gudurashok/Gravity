using System.ComponentModel;

namespace Foresight.Logic.Report
{
    public enum ReportsAmountFormat
    {
        [Description("None")]
        None,
        [Description("Thousands")]
        Thousands,
        [Description("Lacs")]
        Lacs,
        [Description("Crores")]
        Crores
    }
}
