using System;
using System.Windows.Forms;
using Gravity.Root.DataAccess;
using Gravity.Root.Properties;
using Scalable.Shared.Common;

namespace Gravity.Root.Common
{
    public static class Log
    {
        public static void LogError(Exception exception)
        {
            try
            {
                GravityDatabaseFactory.GetInstance().InsertError(
                    new ErrorMessage
                        {
                            DateTime = DateTime.Now,
                            Text = exception.ToString()
                        });
            }
            catch (Exception ex)
            {

#if DEBUG
                ScalableUtil.ShowMessageBox(String.Format("{0}. Original Exception: {1}",
                                                                       Resources.CannotLogException, ex),
                                                         MessageBoxButtons.OK,
                                                         MessageBoxIcon.Exclamation);
#else
                Utils.ShowMessageBox(String.Format("{0}. Message: {1}", 
                                        Resources.CannotLogException, ex.Message),
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
#endif
            }

        }
    }
}

