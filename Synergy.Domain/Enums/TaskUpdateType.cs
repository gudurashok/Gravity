using System.ComponentModel;

namespace Synergy.Domain.Enums
{
    public enum TaskUpdateType
    {
        [Description("Created")]
        Created,
        [Description("Modified")]
        Modified,
        [Description("Checklist Updated")]
        ChecklistUpdated,
        [Description("Completed")]
        Completed,
        [Description("Cancelled")]
        Cancelled,
        [Description("Reopened")]
        Reopened,
        [Description("Progress Changed")]
        ProgressChanged,
        [Description("Commented")]
        Commented,
        [Description("Acknowledged")]
        Acknowledged
    }
}
