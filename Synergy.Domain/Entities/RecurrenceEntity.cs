using System;
using System.ComponentModel.DataAnnotations;
using Raven.Imports.Newtonsoft.Json;
using Synergy.Domain.Enums;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class RecurrenceEntity
    {
        public RecurrenceRepeatFrom RepeatFrom { get; set; }
        public RecurrenceType Type { get; set; }
        public bool IsRegenerated { get; set; }

        [JsonIgnore]
        private int _interval;
        public int Interval
        {
            get { return _interval; }
            set
            {
                if (value == 0)
                    throw new ValidationException(Resources.InvalidRecurrencePattern);
                _interval = value;
            }
        }

        [JsonIgnore]
        private int _daysOfWeek;
        public int DaysOfWeek //Flagged Enum
        {
            get { return _daysOfWeek; }
            set
            {
                if (Type == RecurrenceType.Weekly && !IsRegenerated && value == 0)
                    throw new ValidationException(Resources.SelectWeek);
                _daysOfWeek = value;
            }
        }

        [JsonIgnore]
        private int _dayOfMonth;
        public int DayOfMonth
        {
            get { return _dayOfMonth; }
            set
            {
                if (value > 31)
                    throw new ValidationException(Resources.InvalidDayOfMonth);
                _dayOfMonth = value;
            }
        }

        public DayOfWeekType DayOfWeek { get; set; }
        public DayOfWeekIndexType DayOfWeekIndex { get; set; }
        public MonthName Month { get; set; }
        public DateTime StartDate { get; set; }
        public RecurrenceRangeType RangeType { get; set; }
        public int Occurences { get; set; }

        [JsonIgnore]
        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (RangeType == RecurrenceRangeType.EndByDate && value < StartDate)
                    throw new ValidationException(Resources.EndDateLessThanStartDate);
                _endDate = value;
            }
        }

        public bool Duplicate { get; set; }
        public bool NewGenerated { get; set; }

        public RecurrenceEntity()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Interval = 1;
            Duplicate = true;
            DaysOfWeek = getDaysOfWeek();
        }
        private int getDaysOfWeek()
        {
            var day = DateTime.Today.DayOfWeek.ToString();
            
            if (day == Enums.DaysOfWeek.Sunday.ToString())
                return (int)Enums.DaysOfWeek.Sunday;
            if (day == Enums.DaysOfWeek.Monday.ToString())
                return (int)Enums.DaysOfWeek.Monday;
            if (day == Enums.DaysOfWeek.Tuesday.ToString())
                return (int)Enums.DaysOfWeek.Tuesday;
            if (day == Enums.DaysOfWeek.Wednesday.ToString())
                return (int)Enums.DaysOfWeek.Wednesday;
            if (day == Enums.DaysOfWeek.Thursday.ToString())
                return (int)Enums.DaysOfWeek.Thursday;
            if (day == Enums.DaysOfWeek.Friday.ToString())
                return (int)Enums.DaysOfWeek.Friday;
            if (day == Enums.DaysOfWeek.Saturday.ToString())
                return (int)Enums.DaysOfWeek.Saturday;

            return -1;
        }
    }
}
