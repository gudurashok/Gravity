using Scalable.Shared.Common;
using Scalable.Win.Common;

namespace Mingle.Win.Common
{
    public static class ApplicationFactory
    {
        public static ScalableApplicationBase Instance()
        {
            if (AppConfig.UseTestCoGroup)
            {
                return new TestCoGroupMingleApp();
            }

            return new MingleApp();
        }
    }
}
