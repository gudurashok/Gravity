using System.ComponentModel;
namespace Mingle.Domain.Enums
{
    public enum BloodGroup
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("A +ve")]
        APositive = 1,
        [Description("A -ve")]
        ANegetive = 2,
        [Description("B +ve")]
        BPositive = 3,
        [Description("B -ve")]
        BNegetive = 4,
        [Description("AB +ve")]
        ABPositive = 5,
        [Description("AB -ve")]
        ABNegetive = 6,
        [Description("O +ve")]
        OPositive = 7,
        [Description("O -ve")]
        ONegetive = 8
    }
}
