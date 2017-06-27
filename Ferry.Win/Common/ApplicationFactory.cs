using Scalable.Win.Common;

namespace Ferry.Win.Common
{
    public static class ApplicationFactory
    {
        public static ScalableApplicationBase Instance()
        {
            return new FerryApp();
        }
    }
}
