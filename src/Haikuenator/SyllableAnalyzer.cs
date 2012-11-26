using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haikuenator
{
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
            var group = string.Empty;

            foreach (var letter in Word)
            {
                if (!vowels.Contains(letter))
                {
                    group += letter;
                    continue;
                }
                if(!isFirst)
                {
                    yield return @group;
                    @group = string.Empty;
                }
                group += letter;
                isFirst = false;
            }

            if(!string.IsNullOrEmpty(group))
            {
                yield return group;
            }
        }

        public int GetCount()
        {
            return ParseVowelGroups().Count();
        }
    }
}
