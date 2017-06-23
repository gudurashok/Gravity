using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Reflection;
using Scalable.Shared.Enums;
using Scalable.Shared.Properties;

namespace Scalable.Shared.Common
{
    public static class AppConfig
    {
        public static string AppPath
        {
            get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); }
        }

        public static string CoGroupDataPath
        {
            get { return string.Format(@"{0}\Groups\", DataPath); }
        }

        private static string DataPath
        {
            get { return getDataPath(); }
        }

        private static string getDataPath()
        {
            var dataPath = ConfigurationManager.AppSettings.Get("DataPath");

            if (string.IsNullOrWhiteSpace(dataPath))
                return AppPath + @"\" + "Data";

            dataPath = dataPath.Trim();

            if (dataPath.Length == 1 && !FileNameUtil.IsPathCharValid(Convert.ToChar(dataPath.Substring(0, 1))))
                return AppPath + @"\" + "Data";

            if (dataPath.Trim().Length == 2)
            {
                if (!FileNameUtil.IsPathCharValid(Convert.ToChar(dataPath.Substring(0, 1))))
                    return AppPath + @"\" + "Data";

                if (!FileNameUtil.IsPathValid(dataPath))
                    return AppPath + @"\" + "Data";
            }

            if (dataPath.Length > 2)
            {
                if (!FileNameUtil.IsPathValid(dataPath.Substring(2, dataPath.Length - 2)))
                    dataPath = null;

                if (isAbsolutePath(dataPath))
                    return dataPath;
            }

            return AppPath + @"\" + (string.IsNullOrWhiteSpace(dataPath) ? "Data" : dataPath);
        }

        private static bool isAbsolutePath(string dataPath)
        {
            if (dataPath == null) return false;

            if (dataPath.Substring(0, 2) == @"\\")
                return (dataPath.Substring(2, dataPath.Length - 2).Contains(@"\"));

            return @"\".Contains(dataPath.Substring(0, 1)) || dataPath.Contains(@":");
        }

        private static void saveConfigItem(string key, string value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string SmsRcSql
        {
            get { return ConfigurationManager.AppSettings.Get("SmsRcSql"); }
            set { saveConfigItem("SmsRcSql", value); }
        }

        public static string CoGroupDatabase
        {
            get { return ConfigurationManager.AppSettings.Get("CoGroupDatabase"); }
            set { saveConfigItem("CoGroupDatabase", value); }
        }

        public static string CoGroupId
        {
            get { return ConfigurationManager.AppSettings.Get("CoGroupId"); }
            set { saveConfigItem("CoGroupId", value); }
        }

        public static string AppDbNameSuffix
        {
            get
            {
                var dbNameSuffix = ConfigurationManager.AppSettings.Get("DbNameSuffix");
                return String.IsNullOrWhiteSpace(dbNameSuffix) ? "Gravity" : dbNameSuffix;
            }
        }

        public static Genus AppGenus
        {
            get
            {
                var keyName = typeof(Genus).Name;
                var genus = ConfigurationManager.AppSettings.Get(keyName);
                Genus result;
                if (Enum.TryParse(genus, true, out result))
                    return result;

                throw new ValidationException(String.Format("Incorrect {0} {1}", keyName, genus));
            }
        }

        public static int ListRefreshPollingIntervalInMilliseconds
        {
            get
            {
                const int defaultListRefreshPollingIntervalInMilliseconds = 2500;
                var value = getIntegerConfigItem("ListRefreshPollingIntervalInMilliseconds");
                return value ?? defaultListRefreshPollingIntervalInMilliseconds;
            }
        }

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

        public static string ServerUrl
        {
            get
            {
                var url = ConfigurationManager.AppSettings.Get(Genus.Server.ToString());
                if (string.IsNullOrWhiteSpace(url))
                    throw new ValidationException(Resources.ServerUrlAddressNotDefined);

                return url;
            }
        }

        public static string RavenHQApiKey
        {
            get
            {
                var url = ConfigurationManager.AppSettings.Get("RavenHQApiKey");
                if (string.IsNullOrWhiteSpace(url))
                    throw new ValidationException(Resources.RavenHQApiKeyNotDefined);

                return url;
            }
        }

        public static string RavenHQDatabaseName
        {
            get
            {
                var url = ConfigurationManager.AppSettings.Get("RavenHQDatabaseName");
                if (string.IsNullOrWhiteSpace(url))
                    throw new ValidationException(Resources.RavenHQDatabaseNameNotDefined);

                return url;
            }
        }

        public static bool UseEmbeddedHttpServer
        {
            get { return processBooleanConfigItem("UseEmbeddedHttpServer"); }
        }

        public static bool UseTestCoGroup
        {
            get { return processBooleanConfigItem("UseTestCoGroup"); }
        }

        public static bool CoGroupAutoLogin
        {
            get { return processBooleanConfigItem("CoGroupAutoLogin"); }
        }

        public static bool CreateTestUsers
        {
            get { return processBooleanConfigItem("CreateTestUsers"); }
        }

        public static bool CreateTestParties
        {
            get { return processBooleanConfigItem("CreateTestParties"); }
        }

        public static bool CreateTestTasks
        {
            get { return processBooleanConfigItem("CreateTestTasks"); }
        }

        public static bool CreateTestInsightData
        {
            get { return processBooleanConfigItem("CreateTestInsightData"); }
        }

        private static bool processBooleanConfigItem(string configKey)
        {
            var value = ConfigurationManager.AppSettings.Get(configKey);
            if (string.IsNullOrWhiteSpace(value))
                return false;

            value = value.Substring(0, 1).ToUpper();
            return "TFYN".Contains(value) && !"FN".Contains(value);
        }
    }
}
