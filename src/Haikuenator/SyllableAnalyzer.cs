using System.Collections.Generic;
using System.Linq;

namespace Haikuenator
{
    /// <summary>
    /// Provides very basic phonological analysis of a given word
    /// </summary>
    public class SyllableAnalyzer
    {
        private readonly string Word;

        /// <summary>
        /// Initializes a new instance of the <see cref="SyllableAnalyzer"/> class
        /// </summary>
        /// <param name="word">The word to analyze</param>
        public SyllableAnalyzer(string word)
        {
            Word = word.ToLower();
        }

        /// <summary>
        /// Returns vowel groups - groups of letters containing a single
        /// vowel, from the source word
        /// </summary>
        /// <returns>The vowel groups parsed from the source word</returns>
        public IEnumerable<string> ParseVowelGroups()
        {
            var firstVowel = true;
            var vowelGroup = string.Empty;

            foreach (var letter in Word)
            {
                if (letter.IsVowel())
                {
                    if (!firstVowel)
                    {
                        yield return vowelGroup;
                        vowelGroup = string.Empty;
                    }
                    firstVowel = false;
                }
                vowelGroup += letter;
            }

            if(!string.IsNullOrEmpty(vowelGroup))
            {
                yield return vowelGroup;
            }
        }

        /// <summary>
        /// Get the count of syllables for the source word
        /// </summary>
        /// <returns>The number of syllables the analyzer determines are present in the word</returns>
        public int GetCount()
        {
            var groups = ParseVowelGroups().ToList();

            var previousGroup = string.Empty;
            var count = 0;

            foreach (var currentGroup in groups)
            {
                if (!IsDiphthong(previousGroup + currentGroup[0]))
                {
                    count++;
                }
                previousGroup = currentGroup;
            }

            if(string.Equals(groups.LastOrDefault(), "e"))
            {
                return count - 1;
            }
            return count;
        }

        /// <summary>
        /// Not-very-accurate way of discerning diphthongs "ou", "oi" etc
        /// </summary>
        /// <param name="syllable">String containing the syllable to analyze</param>
        /// <returns>true if the syllable is a diphthong, otherwise false</returns>
        public static bool IsDiphthong(string syllable)
        {
            if(syllable.Length != 2)
            {
                return false;
            }
            return syllable[0].IsVowel() && syllable[1].IsVowel();
        }
    }
}
