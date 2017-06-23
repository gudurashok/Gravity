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
        private const string mainWindowStartPositionKey = "MainWindowStartPosition";
        private const string mainWindowStateKey = "MainWindowState";
        private const string mainWindowLocationKey = "MainWindowLocation";
        private const string mainWindowSizeKey = "MainWindowSize";

        private const string taskWindowStartPositionKey = "TaskWindowStartPosition";
        private const string taskWindowStateKey = "TaskWindowState";
        private const string taskWindowLocationKey = "TaskWindowLocation";
        private const string taskWindowSizeKey = "TaskWindowSize";

        public static FormStartPosition MainWindowStartPosition
        {
            get
            {
                var config = GetConfig(mainWindowStartPositionKey);
                var result = FormStartPosition.CenterScreen;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(mainWindowStartPositionKey, value);
            }
        }

        public static FormWindowState MainWindowState
        {
            get
            {
                var config = GetConfig(mainWindowStateKey);
                var result = FormWindowState.Normal;
                return config != null && Enum.TryParse((string)config.Value, true, out result) ? result : result;
            }
            set
            {
                SetConfig(mainWindowStateKey, value);
            }
        }

        public static Point MainWindowLocation
        {
            get
            {
                var config = GetConfig(mainWindowLocationKey);
                return config == null ? new Point(0, 0)
                                      : new Point(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(mainWindowLocationKey, value);
            }
        }

        public static Size MainWindowSize
        {
            get
            {
                var config = GetConfig(mainWindowSizeKey);
                return config == null ? new Size(0, 0)
                                      : new Size(Convert.ToInt32(config.Value.ToString().Split(',')[0]),
                                                Convert.ToInt32(config.Value.ToString().Split(',')[1]));
            }
            set
            {
                SetConfig(mainWindowSizeKey, value);
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
    }
}
