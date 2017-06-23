using System;

namespace Scalable.Shared.Model
{
    public class DatePeriod
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public override string ToString()
        {
            return string.Format("({0}-{1})", 
                                    From.ToShortDateString(), 
                                    To.ToShortDateString());
        }

        public string ToDateTimeString()
        {
            return string.Format("({0} {1} - {2} {3})", 
                                    From.ToShortDateString(), 
                                    From.ToShortTimeString(), 
                                    To.ToShortDateString(), 
                                    To.ToShortTimeString());
        }

        public string ToYearString()
        {
            return string.Format("{0}-{1}", From.Year, To.Year);
        }

        public DatePeriod AddYears(int value)
        {
            return new DatePeriod { From = From.AddYears(value), To = To.AddYears(value) };
        }
    }
}
