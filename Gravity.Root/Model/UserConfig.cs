using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Gravity.Root.Repositories;
using System.Drawing;

namespace Gravity.Root.Model
{
    public static class UserConfig
    {
        public const string synergyMainWindowStartPositionKey = "SynergyMainWindowStartPosition";
        public const string synergyMainWindowStateKey = "SynergyMainWindowState";
        public const string synergyMainWindowLocationKey = "SynergyMainWindowLocation";
        public const string synergyMainWindowSizeKey = "SynergyMainWindowSize";

        public const string insightMainWindowStartPositionKey = "InsightMainWindowStartPosition";
        public const string insightMainWindowStateKey = "InsightMainWindowState";
        public const string insightMainWindowLocationKey = "InsightMainWindowLocation";
        public const string insightMainWindowSizeKey = "InsightMainWindowSize";

        public const string ferryMainWindowStartPositionKey = "FerryMainWindowStartPosition";
        public const string ferryMainWindowStateKey = "FerryMainWindowState";
        public const string ferryMainWindowLocationKey = "FerryMainWindowLocation";
        public const string ferryMainWindowSizeKey = "FerryMainWindowSize";

        public const string foresightMainWindowStartPositionKey = "ForesightMainWindowStartPosition";
        public const string foresightMainWindowStateKey = "ForesightMainWindowState";
        public const string foresightMainWindowLocationKey = "ForesightMainWindowLocation";
        public const string foresightMainWindowSizeKey = "ForesightMainWindowSize";

        public const string taskWindowStartPositionKey = "TaskWindowStartPosition";
        public const string taskWindowStateKey = "TaskWindowState";
        public const string taskWindowLocationKey = "TaskWindowLocation";
        public const string taskWindowSizeKey = "TaskWindowSize";

        public static FormStartPosition SynergyMainWindowStartPosition
        {
            get
            {
                var config = GetConfig(synergyMainWindowStartPositionKey);
                var result = FormStartPosition.CenterScreen;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(synergyMainWindowStartPositionKey, value);
            }
        }

        public static FormWindowState SynergyMainWindowState
        {
            get
            {
                var config = GetConfig(synergyMainWindowStateKey);
                var result = FormWindowState.Normal;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(synergyMainWindowStateKey, value);
            }
        }

        public static Point SynergyMainWindowLocation
        {
            get
            {
                var config = GetConfig(synergyMainWindowLocationKey);
                return config == null ? new Point(0, 0)
                                      : new Point(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(synergyMainWindowLocationKey, value);
            }
        }

        public static Size SynergyMainWindowSize
        {
            get
            {
                var config = GetConfig(synergyMainWindowSizeKey);
                return config == null ? new Size(0, 0)
                                      : new Size(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(synergyMainWindowSizeKey, value);
            }
        }

        public static FormStartPosition InsightMainWindowStartPosition
        {
            get
            {
                var config = GetConfig(insightMainWindowStartPositionKey);
                var result = FormStartPosition.CenterScreen;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(insightMainWindowStartPositionKey, value);
            }
        }

        public static FormWindowState InsightMainWindowState
        {
            get
            {
                var config = GetConfig(insightMainWindowStateKey);
                var result = FormWindowState.Normal;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(insightMainWindowStateKey, value);
            }
        }

        public static Point InsightMainWindowLocation
        {
            get
            {
                var config = GetConfig(insightMainWindowLocationKey);
                return config == null ? new Point(0, 0)
                                      : new Point(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(insightMainWindowLocationKey, value);
            }
        }

        public static Size InsightMainWindowSize
        {
            get
            {
                var config = GetConfig(insightMainWindowSizeKey);
                return config == null ? new Size(0, 0)
                                      : new Size(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(insightMainWindowSizeKey, value);
            }
        }

        public static FormStartPosition FerryMainWindowStartPosition
        {
            get
            {
                var config = GetConfig(ferryMainWindowStartPositionKey);
                var result = FormStartPosition.CenterScreen;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(ferryMainWindowStartPositionKey, value);
            }
        }

        public static FormWindowState FerryMainWindowState
        {
            get
            {
                var config = GetConfig(ferryMainWindowStateKey);
                var result = FormWindowState.Normal;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(ferryMainWindowStateKey, value);
            }
        }

        public static Point FerryMainWindowLocation
        {
            get
            {
                var config = GetConfig(ferryMainWindowLocationKey);
                return config == null ? new Point(0, 0)
                                      : new Point(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(ferryMainWindowLocationKey, value);
            }
        }

        public static Size FerryMainWindowSize
        {
            get
            {
                var config = GetConfig(ferryMainWindowSizeKey);
                return config == null ? new Size(0, 0)
                                      : new Size(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(ferryMainWindowSizeKey, value);
            }
        }

        public static FormStartPosition ForesightMainWindowStartPosition
        {
            get
            {
                var config = GetConfig(foresightMainWindowStartPositionKey);
                var result = FormStartPosition.CenterScreen;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(foresightMainWindowStartPositionKey, value);
            }
        }

        public static FormWindowState ForesightMainWindowState
        {
            get
            {
                var config = GetConfig(foresightMainWindowStateKey);
                var result = FormWindowState.Normal;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(foresightMainWindowStateKey, value);
            }
        }

        public static Point ForesightMainWindowLocation
        {
            get
            {
                var config = GetConfig(foresightMainWindowLocationKey);
                return config == null ? new Point(0, 0)
                                      : new Point(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(foresightMainWindowLocationKey, value);
            }
        }

        public static Size ForesightMainWindowSize
        {
            get
            {
                var config = GetConfig(foresightMainWindowSizeKey);
                return config == null ? new Size(0, 0)
                                      : new Size(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(foresightMainWindowSizeKey, value);
            }
        }

        public static FormStartPosition TaskWindowStartPosition
        {
            get
            {
                var config = GetConfig(taskWindowStartPositionKey);
                var result = FormStartPosition.CenterScreen;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(taskWindowStartPositionKey, value);
            }
        }

        public static FormWindowState TaskWindowState
        {
            get
            {
                var config = GetConfig(taskWindowStateKey);
                var result = FormWindowState.Normal;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(taskWindowStateKey, value);
            }
        }

        public static Point TaskWindowLocation
        {
            get
            {
                var config = GetConfig(taskWindowLocationKey);
                return config == null ? new Point(0, 0)
                                      : new Point(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(taskWindowLocationKey, value);
            }
        }

        public static Size TaskWindowSize
        {
            get
            {
                var config = GetConfig(taskWindowSizeKey);
                return config == null ? new Size(0, 0)
                                      : new Size(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(taskWindowSizeKey, value);
            }
        }

        public static UserConfigEntity GetConfig(string keyName, string userId = null)
        {
            var repo = new CoGroupRepository();
            return repo.GetUserConfig(userId ?? GravitySession.User.Entity.Id, keyName);
        }

        public static IEnumerable<UserConfigEntity> GetConfigs(string keyName, object value = null)
        {
            var repo = new CoGroupRepository();
            return repo.GetUserConfigs(keyName, value);
        }

        public static void SetConfig(string keyName, object value, string userId = null)
        {
            userId = userId ?? GravitySession.User.Entity.Id;
            var repo = new CoGroupRepository();
            var config = repo.GetUserConfig(userId, keyName);
            if (config == null)
            {
                config = UserConfigEntity.New();
                config.UserId = userId;
                config.Name = keyName;
            }
            config.Value = value;
            repo.SaveUserConfig(config);
        }

        public static void SaveSettings(string userId, IDictionary<string, object> settings)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return;

            var repo = new CoGroupRepository();
            using (var s = repo.Store.OpenSession())
            {
                foreach (var setting in settings)
                {
                    var config = repo.GetUserConfig(userId, setting.Key);
                    if (config == null)
                    {
                        config = UserConfigEntity.New();
                        config.UserId = userId;
                        config.Name = setting.Key;
                    }
                    config.Value = setting.Value;
                    s.Store(config);
                }

                s.SaveChanges();
            }
        }
    }
}
