using Scalable.Shared.Common;
using Scalable.Win.Common;

namespace Ferry.Win.Common
{
    public static class ApplicationFactory
    {
        public static ScalableApplicationBase Instance()
        {
#if DEBUG
            if (AppConfig.UseTestCoGroup)
            {
                return new TestCoGroupFerryApp();
            }
#endif
            return new FerryApp();
        }
    }
}
