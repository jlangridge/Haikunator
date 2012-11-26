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
            var isFirst = true;
            var vowelGroup = string.Empty;

            foreach (var letter in Word)
            {
                if (letter.IsVowel())
                {
                    if (!isFirst)
                    {
                        yield return vowelGroup;
                        vowelGroup = string.Empty;
                    }
                    isFirst = false;
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

            var lastGroup = groups.LastOrDefault();
            if(lastGroup != null && lastGroup.Equals("e"))
            {
                return count -1;
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
