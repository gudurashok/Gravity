using Scalable.Shared.Enums;
using Scalable.Win.Events;

namespace Scalable.Win.Controls
{
    public interface ITextBoxBase
    {
        string Text { get; set; }
        int SelectionLength { get; set; }
        void SelectAll();
        int SelectionStart { get; set; }
        void Select(int start, int length);
        string InputFilterExpr { get; set; }
        TextCaseStyle AutoCasing { get; set; }
        event PicklistSearchEventHandler Search;
    }
}
