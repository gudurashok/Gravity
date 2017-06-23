using System;

namespace Scalable.Shared.Extensions
{
    public static class DatePeriodExtentions
    {
        public static bool IsBetween(this DateTime date, DateTime minimum, DateTime maximum)
        {
            return date.Date > minimum.Date && date.Date < maximum.Date;
        }
    }
}
