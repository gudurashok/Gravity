using System;

namespace Insight.UC.Common
{
    public interface ISetup
    {
        void Initialize();
        event EventHandler<EventArgs> ItemSaved;
    }
}
