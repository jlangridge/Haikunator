using System;
using System.IO;
using System.Linq;

namespace Haikuenator
{
    /// <summary>
    ///   Represents a single line in the generated Haiku
    /// </summary>
    public class Line
    {
        public readonly int Syllables;

        /// <summary>
        ///   Initializes a new instance of the <see cref="Line" /> class
        /// </summary>
        /// <param name="syllables"> Number of syllables the line should contain </param>
        public Line(int syllables)
        {
            Syllables = syllables;
        }

        public string Text { get; private set; }

        /// <summary>
        ///   Boolean to show whether the input string matches the specified number of syllables for this line
        /// </summary>
        /// <param name="candidateText"> The <see cref="string" /> to analyze </param>
        /// <returns> True if the candidate string matches the syllable count, otherwise false </returns>
        public bool CanRead(string candidateText)
        {
            var tokens = new WordTokenizer(candidateText).GetTokens();

            var syllableCount = tokens.Sum(token => new SyllableAnalyzer(token).GetCount());
            return syllableCount == Syllables;
        }

        /// <summary>
        ///   Reads the number of syllables for the line from the supplied <see cref="TextReader" />
        /// </summary>
        /// <param name="input"> The <see cref="TextReader" /> object to use </param>
        public void ReadFrom(TextReader input)
        {
            var tokens = new WordTokenizer(input).GetTokens();
            var syllableTotal = 0;

            var separator = string.Empty;

            foreach (var token in tokens)
            {
                var syllableCount = new SyllableAnalyzer(token).GetCount();
                if (syllableTotal + syllableCount > Syllables)
                {
                    var errorString = string.Format("The supplied text does not fit {0} syllables", Syllables);
                    throw new ArgumentException(errorString, "input");
                }
                syllableTotal += syllableCount;
                Text += separator + token;

                separator = " ";

                if (syllableTotal == Syllables)
                {
                    break;
                }
            }
        }

        public override string ToString()
        {
            return Text;
        }
    }
}