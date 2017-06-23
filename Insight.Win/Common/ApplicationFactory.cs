using Scalable.Shared.Common;
using Scalable.Win.Common;

namespace Insight.Win.Common
{
    public static class ApplicationFactory
    {
        public static ScalableApplicationBase Instance()
        {
#if DEBUG
            if (AppConfig.UseTestCoGroup)
            {
                return new TestCoGroupInsightApp();
            }
#endif
            return new InsightApp();
        }
    }
}
