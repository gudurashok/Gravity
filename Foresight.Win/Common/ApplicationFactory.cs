using Scalable.Shared.Common;
using Scalable.Win.Common;

namespace Foresight.Win.Common
{
    public static class ApplicationFactory
    {
        public static ScalableApplicationBase Instance()
        {
            return new ForesightApp();
        }
    }
}
