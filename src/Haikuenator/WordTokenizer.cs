using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Haikuenator
{
    /// <summary>
    ///   Imperfect (good-enough?) implementation of a lexical tokenizer. Not suitable for anything other than a bit of fun..
    /// </summary>
    public class WordTokenizer
    {
        private readonly string Source;

        public WordTokenizer(string source)
        {
            Source = source;
        }

        public string GetSanitizedString()
        {
            var punctuationRemoved = Regex.Replace(Source, @"[^A-Za-z ]", string.Empty);
            return Regex.Replace(punctuationRemoved, @"\s+", " ");
        }

        public IEnumerable<string> ParseTokens()
        {
            return GetSanitizedString().Split(' ');
        }
    }
}