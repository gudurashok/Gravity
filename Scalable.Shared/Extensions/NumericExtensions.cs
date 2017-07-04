namespace Scalable.Shared.Extensions
{
    public static class NumericExtensions
    {
        public static bool IsBetween(this int number, int minimum, int maximum)
        {
            return number >= minimum && number <= maximum;
        }

        public static bool IsBetween(this decimal number, decimal minimum, decimal maximum)
        {
            return number >= minimum && number <= maximum;
        }

        public static bool IsBetween(this float number, float minimum, float maximum)
        {
            return number >= minimum && number <= maximum;
        }

        public static bool IsBetween(this double number, double minimum, double maximum)
        {
            return number >= minimum && number <= maximum;
        }

        public static bool IsBetween(this long number, long minimum, long maximum)
        {
            return number >= minimum && number <= maximum;
        }
    }
}
