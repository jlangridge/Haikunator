using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IEnumerable<string> ParseVowelGroups()
        {
            var vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y'};

            var isFirst = true;
            var vowelGroup = string.Empty;

            foreach (var letter in Word)
            {
                if (vowels.Contains(letter))
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

        public int GetCount()
        {
            var groups = ParseVowelGroups().ToList();
            var lastGroup = groups.LastOrDefault();
            if(lastGroup != null && lastGroup.Equals("e"))
            {
                return groups.Count() -1;
            }
            return ParseVowelGroups().Count();
        }
    }
}
