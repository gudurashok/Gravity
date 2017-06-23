using System;
using System.ComponentModel;

namespace Insight.Domain.Enums
{
    [Flags]
    public enum AccountTypes
    {
        [Description("All")]
        All = 0,
        [Description("Customers")]
        Customers = 21,
        [Description("Vendors")]
        Vendors = 10
    }
}
