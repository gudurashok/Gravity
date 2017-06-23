using Gravity.Root.Entities;
using Gravity.Root.Repositories;
using Mingle.Domain.Repositories;

namespace Mingle.Domain.Model
{
    public static class SysConfig
    {
        private const string defaultDataInsertedKey = "MingleDefaultDataInserted";
        private const string testDataInsertedKey = "MingleTestPartiesInserted";
        private const string coGroupPartyIdKey = "CoGroupPartyId";

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

        public static string CoGroupPartyId
        {
            get
            {
                var config = getConfig(coGroupPartyIdKey);
                return config == null ? "" : config.Value.ToString();
            }
            set { setConfig(coGroupPartyIdKey, value); }
        }

        public static Party CoGroupParty
        {
            get
            {
                var config = getConfig(coGroupPartyIdKey);
                if (config == null)
                    return null;

                var id = config.Value.ToString();
                var repo = new PartyRepository();
                return repo.GetById(id, true, true);
            }
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
