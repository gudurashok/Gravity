using Scalable.Shared.Common;
using Scalable.Win.Common;

namespace Synergy.Win.Common
{
    public static class ApplicationFactory
    {
        public static ScalableApplicationBase Instance()
        {
            if (AppConfig.UseTestCoGroup)
            {
                return new TestCoGroupSynergyApp();
            }

            return new SynergyApp();
        }
    }
}
