using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Scalable.Shared.Common
{
    public static class EnumUtil
    {
        #region Public Methods

        public static string GetEnumDescription(object enumValue)
        {
            var enumType = enumValue.GetType();
            var fieldInfos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var fieldInfo in fieldInfos)
            {
                if (enumValue.ToString().Equals(fieldInfo.GetValue(fieldInfo.Name).ToString()))
                {
                    var attributes = (DescriptionAttribute[])fieldInfo
                                        .GetCustomAttributes(typeof(DescriptionAttribute), false);
                    return attributes.Length <= 0
                               ? fieldInfo.GetValue(fieldInfo.Name).ToString()
                               : attributes[0].Description;
                }

                //if (attributes.Length <= 0 && enumValue.ToString().Equals(fieldInfo.GetValue(fieldInfo.Name).ToString()))
                //    return fieldInfo.GetValue(fieldInfo.Name).ToString();

                //if (enumValue.ToString().Equals(fieldInfo.GetValue(fieldInfo.Name).ToString()))
                //    return attributes[0].Description;
            }

            return string.Empty;
        }

        public static void LoadEnumListItems(ComboBox control, Type enumType, object defaultValue, int ignoreItem = -1)
        {
            LoadEnumListItems(control, enumType, ignoreItem);
            SetEnumListItem(control, defaultValue);
        }

        public static void LoadEnumListItems(ListControl control, Type enumType, int ignoreItem = -1)
        {
            bindListControl(control, "Key", "Value", getEnumList(enumType, ignoreItem));
        }

        public static void SetEnumListItem(ComboBox control, object value)
        {
            control.SelectedIndex = control.FindString(GetEnumDescription(value));
        }

        #endregion

        #region Helper Methods

        private static string[] getEnumDescriptions(Type enumType)
        {
            var fieldInfos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return (from fieldInfo in fieldInfos
                    let attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    select attributes.Length > 0 ? attributes[0].Description : fieldInfo.GetValue(fieldInfo.Name).ToString()).ToArray();
        }

        private static List<KeyValuePair<int, string>> getEnumList(Type enumType, int ignoreItem)
        {
            var values = Enum.GetValues(enumType);
            var descriptions = getEnumDescriptions(enumType);
            var result = values.Cast<object>().Select((t, index) =>
                         new KeyValuePair<int, string>((int)values.GetValue(index), descriptions[index])).ToList();

            return ignoreItem != -1 ? result.Where(c => c.Key != ignoreItem).ToList() : result;
        }

        private static void bindListControl(ListControl control, string valueMember,
                                            string displayMember, object dataSource)
        {
            control.ValueMember = valueMember;
            control.DisplayMember = displayMember;
            control.DataSource = dataSource;
        }

        #endregion
    }
}
