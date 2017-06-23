using Gravity.Root.Entities;
using Gravity.Root.Repositories;

namespace Synergy.Domain.Model
{
    public static class SysConfig
    {
        private const string testDataInsertedKey = "SynergyTestDataInserted";
        private const string defaultDataInsertedKey = "SynergyDefaultDataInserted";

        public static bool TestDataInserted
        {
            get
            {
                var config = getConfig(testDataInsertedKey);
                return config != null && (bool)config.Value;
            }
            set { setConfig(testDataInsertedKey, value); }
        }

        public static bool DefaultDataInserted
        {
            get
            {
                var config = getConfig(defaultDataInsertedKey);
                return config != null && (bool)config.Value;
            }
            set { setConfig(defaultDataInsertedKey, value); }
        }

        private static SysConfigEntity getConfig(string keyName)
        {
            var repo = new CoGroupRepository();
            return repo.GetSysConfig(keyName);
        }

        private static void setConfig(string keyName, object value)
        {
            var repo = new CoGroupRepository();
            var config = repo.GetSysConfig(keyName);
            if (config == null)
            {
                config = SysConfigEntity.New();
                config.Name = keyName;
            }
            config.Value = value;
            repo.SaveSysConfig(config);
        }
    }
}
