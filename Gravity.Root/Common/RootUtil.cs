using System;
using Gravity.Root.Repositories;
using Scalable.Shared.Common;
using Gravity.Root.Properties;
using System.Windows.Forms;
using Raven.Imports.Newtonsoft.Json;

namespace Gravity.Root.Common
{
    public static class ObjectCloneExtensions
    {
        public static T Clone<T>(this T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            var deserializeSettings = new JsonSerializerSettings
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }
    }

    public class RootUtil
    {
        public static void LogError(Exception exception)
        {
            try
            {
                var repo = new CoGroupRepository();
                repo.Insert(new ErrorMessage
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
