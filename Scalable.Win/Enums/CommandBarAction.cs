using System;

namespace Scalable.Win.Enums
{
    [Flags]
    public enum CommandBarAction
    {
        Default = 0,
        Add = 1,
        Edit = 2,
        New = 4,
        Open = 8,
        Save = 16,
        Delete = 32,
        Cancel = 64,
        Close = 128
    }

    public class CommandBarActionWrapper
    {
        public CommandBarAction Action { get; private set; }

        public CommandBarActionWrapper(CommandBarAction action)
        {
            Action = action;
        }

        public bool IsOpen()
        {
            return (Action & CommandBarAction.Open) == CommandBarAction.Open;
        }

        public bool IsNew()
        {
            return (Action & CommandBarAction.New) == CommandBarAction.New;
        }

        public bool IsSave()
        {
            return (Action & CommandBarAction.Save) == CommandBarAction.Save;
        }

        public bool IsOnlySave()
        {
            return Action == CommandBarAction.Save;
        }

        public bool IsAdd()
        {
            return (Action & CommandBarAction.Add) == CommandBarAction.Add;
        }

        public bool IsEdit()
        {
            return (Action & CommandBarAction.Edit) == CommandBarAction.Edit;
        }

        public bool IsSaveAndClose()
        {
            return IsSave() ||
                    ((Action & CommandBarAction.Save) == CommandBarAction.Save &&
                    (Action & CommandBarAction.Close) == CommandBarAction.Close);
        }

        public bool IsClose()
        {
            return (Action & CommandBarAction.Close) == CommandBarAction.Close;
        }

        public bool IsDelete()
        {
            return (Action & CommandBarAction.Delete) == CommandBarAction.Delete;
        }

        public bool IsCancel()
        {
            return (Action & CommandBarAction.Cancel) == CommandBarAction.Cancel;
        }
    }
}