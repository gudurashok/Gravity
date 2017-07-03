using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace Ferry.Insight.Service
{
    public static class ServiceConfig
    {
        public static void WriteLog(string message)
        {
            const string eventLogSourceName = "Gravity.Ferry.Insight.Import";
            EventLog.WriteEntry(eventLogSourceName, message);
        }

        public static int ImportIntervalInMilliseconds
        {
            get
            {
                const int defaultImportIntervalInMilliseconds = 30000;
                var value = getIntegerConfigItem("ImportIntervalInMilliseconds");
                return value ?? defaultImportIntervalInMilliseconds;
            }
        }

        public static string ImportServiceStartType
        {
            get { return ConfigurationManager.AppSettings.Get("ImportServiceStartType"); }
        }

        //public static bool CreateTestUsers
        //{
        //    get { return processBooleanConfigItem("CreateTestUsers"); }
        //}

        //private static bool processBooleanConfigItem(string configKey)
        //{
        //    var value = ConfigurationManager.AppSettings.Get(configKey);
        //    if (string.IsNullOrWhiteSpace(value))
        //        return false;

        //    value = value.Substring(0, 1).ToUpper();
        //    return "TFYN".Contains(value) && !"FN".Contains(value);
        //}

        private static int? getIntegerConfigItem(string configKey)
        {
            var value = ConfigurationManager.AppSettings.Get(configKey);
            if (string.IsNullOrWhiteSpace(value))
                return null;

            int result;
            if (int.TryParse(value, out result))
                return result;

            return null;
        }
    }
}
