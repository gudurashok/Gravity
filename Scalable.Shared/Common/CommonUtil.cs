using System;
using System.Reflection;
using System.Security.Principal;

namespace Scalable.Shared.Common
{
    public static class CommonUtil
    {
        #region Amount Format

        public const string AmountFormatWithCrDbZero = "##,##,##0.00 CR;##,##,##0.00 DB;Zero";
        public const string AmountFormatWithCrDb = "##,##,##0.00 CR;##,##,##0.00 DB;0.00";
        public const string AmountFormat = "##,##,##,##0.00";
        public const string AmountFormatBlankWhenZero = "##,##,##0.00;##,##,##0.00; ";

        public static string GetAmountFormat(bool withDbCr)
        {
            return withDbCr ? AmountFormatWithCrDbZero : AmountFormat;
        }

        #endregion

        #region Public Methods

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

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
