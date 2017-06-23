using System;
using System.Reflection;

namespace Gravity.Root.Common
{
    public class GravityApplication
    {
        public static string GetProductName()
        {
            var asm = Assembly.GetEntryAssembly();
            var attr = (AssemblyProductAttribute)
                        Attribute.GetCustomAttribute(asm, typeof(AssemblyProductAttribute));

            return attr.Product;
        }
    }
}
