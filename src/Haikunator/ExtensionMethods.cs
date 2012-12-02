using System.Linq;
using System.Text.RegularExpressions;

namespace Haikuenator
{
    public static class ExtensionMethods
    {
        public static bool IsVowel(this char c)
        {
            return new[] {'a', 'e', 'i', 'o', 'u', 'y'}.Contains(c);
        }

        public static string RemoveDigits(this string s)
        {
            return Regex.Replace(s, "[0-9]", string.Empty);
        }
    }
}
