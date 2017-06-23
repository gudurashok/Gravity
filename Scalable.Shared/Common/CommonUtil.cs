using System;
using System.Reflection;

namespace Scalable.Shared.Common
{
    public static class CommonUtil
    {
        #region Constatnts

        public const string AmountFormatWithCrDb = "##,##,##0.00 CR;##,##,##0.00 DB;Zero";
        public const string AmountFormat = "##,##,##0.00";
        public const string AmountFormatBlankWhenZero = "##,##,##0.00;##,##,##0.00; ";

        #endregion

        #region Public Methods

        public static string GetProdcutName()
        {
            var asm = Assembly.GetEntryAssembly();
            var attr = (AssemblyProductAttribute)
                        Attribute.GetCustomAttribute(asm, typeof(AssemblyProductAttribute));

            return attr.Product;
        }

        #endregion
    }
}
