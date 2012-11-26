using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Haikuenator
{
    /// <summary>
    /// Imperfect (good-enough?) implementation of a lexical tokenizer.
    /// Not really suitable for anything other than a bit of fun..
    /// </summary>
    public class WordTokenizer
    {
        private readonly string Source;


        /// <summary>
        /// Initializes a new instance of the <see cref="WordTokenizer"/> class
        /// </summary>
        /// <param name="source">The source of words to tokenize</param>
        public WordTokenizer(string source)
        {
            Source = source;
        }

        /// <summary>
        /// Sanitizes a string for use with the <see cref="SyllableAnalyzer"/>. This means removing
        /// punctuation and digits etc.
        /// </summary>
        /// <returns>The sanitized string</returns>
        public string GetSanitizedString()
        {
            var punctuationRemoved = Regex.Replace(Source, @"[^A-Za-z ]", string.Empty);
            return Regex.Replace(punctuationRemoved, @"\s+", " ");
        }


        /// <summary>
        /// Parse tokens from the <see cref="Source"/> string
        /// </summary>
        /// <returns>Each parsed token</returns>
        public IEnumerable<string> ParseTokens()
        {
            return GetSanitizedString().Split(' ');
        }
    }
}