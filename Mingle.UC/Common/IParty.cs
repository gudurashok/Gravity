using Scalable.Win.FormControls;

namespace Mingle.UC.Common
{
    public interface IParty
    {
        UBaseForm Control { get; }
        void Initialize();
        void Save();
        void RefreshLists();
    }
}
