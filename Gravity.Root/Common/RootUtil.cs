using System;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Gravity.Root.Properties;
using System.Windows.Forms;

namespace Gravity.Root.Common
{
    public class RootUtil
    {
        public static void LogError(Exception exception)
        {
            try
            {
                var repo = new CoGroupRepository();
                repo.Save(new ErrorMessage
                        {
                            DateTime = DateTime.Now,
                            Text = exception.ToString()
                        });

            }
            catch (Exception ex)
            {

#if DEBUG
                MessageBoxUtil.ShowMessageBox(string.Format("{0}. Original Exception: {1}",
                                        Resources.CannotLogException, ex),
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
#else
                MessageBoxUtil.ShowMessageBox(string.Format("{0}. Message: {1}",
                                        Resources.CannotLogException, ex.Message),
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
#endif
            }
        }
    }
}
