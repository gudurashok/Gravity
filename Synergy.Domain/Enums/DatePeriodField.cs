using System.ComponentModel;

namespace Synergy.Domain.Enums
{
    public enum DatePeriodField
    {
        [Description("(None)")]
        None = 0,
        [Description("Created Date")]
        CreatedOn = 1,
        [Description("Due Date")]
        DueDate = 2,
        [Description("Start Date")]
        StartDate = 3,
        [Description("Completed Date")]
        CompletedOn = 4
    }
}
