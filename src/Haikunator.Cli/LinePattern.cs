using System.Linq;

namespace Haikunator.Cli
{
    public class LinePattern
    {
        private int[] LineLengths;

        public static LinePattern Default
        {
            get
            {
                return new LinePattern
                           {
                               LineLengths = new[] {5, 7, 5}
                           };
            }
        }

        public Haiku CreateHaiku()
        {
            return new Haiku(LineLengths);
        }

        public static LinePattern Parse(string argument)
        {
            var pattern = new LinePattern();
            var patternStrings = argument.Split('-');
            pattern.LineLengths = patternStrings.Select(int.Parse).ToArray();
            return pattern;
        }
    }
}