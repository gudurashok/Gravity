using System;
using System.Windows.Forms;

namespace Scalable.Shared.Common
{
    public static class MessageBoxUtil
    {
        public static void ShowMessage(string message)
        {
            ShowMessageBox(message, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void ShowError(Exception exception)
        {
#if DEBUG
            ShowMessageBox(exception.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#else
            ShowMessageBox(exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
#endif
        }

        public static DialogResult GetConfirmationOKCancel(string message)
        {
            return GetConfirmation(message, MessageBoxButtons.OKCancel);
        }

        public static DialogResult GetConfirmationYesNo(string message)
        {
            return GetConfirmation(message, MessageBoxButtons.YesNo);
        }

        private static DialogResult GetConfirmation(string message,
                                                    MessageBoxButtons buttons)
        {
            return ShowMessageBox(message, buttons, MessageBoxIcon.Question);
        }

        public static DialogResult ShowMessageBox(string message,
                                                  MessageBoxButtons buttons,
                                                  MessageBoxIcon icon)
        {
            return MessageBox.Show(message, CommonUtil.GetProdcutName(),
                                   buttons, icon, MessageBoxDefaultButton.Button1);
        }
    }
}
