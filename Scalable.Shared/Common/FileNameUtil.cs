using System.Linq;
using System.Diagnostics;

namespace Scalable.Shared.Common
{
    public static class FileNameUtil
    {
        const string invalidChars = @"""/:?<>*|";

        public static string GetValidFileName(string fileName)
        {
            const string charsInvalid = invalidChars + @"\";
            return charsInvalid.Aggregate(fileName,
                    (current, invalidChar) => current.Replace(invalidChar.ToString(), ""));
        }

        public static bool IsPathValid(string path)
        {
            return invalidChars.All(c => !path.Contains(c));
        }

        public static bool IsPathCharValid(char ch)
        {
            return invalidChars.All(c => ch != c);
        }
    }
}
