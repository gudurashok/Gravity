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
        public static void LogError(string source, Exception exception)
        {
            LogText(source, exception.ToString());
        }

        public static void LogText(string source, string text)
        {
            try
            {
                var repo = new CoGroupRepository();
                repo.Insert(new ErrorMessage
                {
                    Source = source,
                    DateTime = DateTime.Now,
                    Text = text,
                });
            }
            catch (Exception ex)
            {

#if DEBUG
                MessageBoxUtil.ShowMessageBox(
                                    $"{Resources.CannotLogException}. Original Exception: {ex}",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
#else
                MessageBoxUtil.ShowMessageBox(
                                    $"{Resources.CannotLogException}. Original Exception: {ex.Message}",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
#endif
            }
        }
    }
}
