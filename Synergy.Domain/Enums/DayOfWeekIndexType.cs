using System.ComponentModel;

namespace Synergy.Domain.Enums
{
    public enum DayOfWeekIndexType
    {
        Day,
        Weekday,
        [Description("Weekend day")]
        WeekendDay,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
