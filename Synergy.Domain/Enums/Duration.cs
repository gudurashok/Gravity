using System.ComponentModel;

namespace Synergy.Domain.Enums
{
    public enum Duration
    {
        [Description("0 mins")]
        ZeroMins = 0,
        [Description("5 mins")]
        FiveMins = 5,
        [Description("10 mins")]
        TenMins = 10,
        [Description("15 mins")]
        FifteenMins = 15,
        [Description("20 mins")]
        TwentyMins = 20,
        [Description("30 mins")]
        ThirtyMins = 30,
        [Description("1 hour")]
        OneHour = 60,
        [Description("2 hours")]
        TwoHours = 120,
        [Description("3 hours")]
        ThreeHours = 180,
        [Description("4 hours")]
        FourHours = 240,
        [Description("5 hours")]
        FiveHours = 300,
        [Description("6 hours")]
        SixHours = 360,
        [Description("7 hours")]
        SevenHours = 420,
        [Description("8 hours")]
        EightHours = 480,
        [Description("9 hours")]
        NineHours = 540,
        [Description("10 hours")]
        TenHours = 600,
        [Description("11 hours")]
        ElevenHours = 660,
        [Description("12 hours")]
        TwelveHours = 720,
        [Description("18 hours")]
        EighteenHours = 1080,
        [Description("1 day")]
        OneDay = 1440,
        [Description("2 days")]
        TwoDays = 2880,
        [Description("3 days")]
        ThreeDays = 4320,
        [Description("4 days")]
        FourDays = 5760,
        [Description("1 week")]
        OneWeek = 10080,
        [Description("2 weeks")]
        TwoWeeks = 20160
    }
}
