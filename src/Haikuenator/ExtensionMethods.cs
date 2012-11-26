using System.Linq;

namespace Haikuenator
{
    public static class ExtensionMethods
    {
        public static bool IsVowel(this char c)
        {
            return new[] {'a', 'e', 'i', 'o', 'u', 'y'}.Contains(c);
        }
    }
}
