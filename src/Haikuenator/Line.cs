using System.IO;
using System.Linq;

namespace Haikuenator
{
    /// <summary>
    /// Represents a single line in the generated Haiku
    /// </summary>
    public class Line
    {
        private readonly int Syllables;

        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class
        /// </summary>
        /// <param name="syllables">Number of syllables the line should contain</param>
        public Line(int syllables)
        {
            Syllables = syllables;
        }

        /// <summary>
        /// Boolean to show whether the input string matches the specified number
        /// of syllables for this line
        /// </summary>
        /// <param name="candidateText">The <see cref="string"/> to analyze</param>
        /// <returns>True if the candidate string matches the syllable count, otherwise false</returns>
        public bool CanRead(string candidateText)
        {
            var tokens = new WordTokenizer(candidateText).ParseTokens();
            
            var syllableCount = tokens.Sum(token => new SyllableAnalyzer(token).GetCount());
            return syllableCount == Syllables;
        }

        /// <summary>
        /// Reads the number of syllables for the line from the supplied <see cref="TextReader"/>
        /// </summary>
        /// <param name="input">The <see cref="TextReader"/> object to use</param>
        public void ReadFrom(TextReader input)
        {
            
        }

    }
}