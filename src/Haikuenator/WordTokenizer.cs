using System;
using System.Collections.Generic;

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

        public IEnumerable<string> ParseTokens()
        {
            return Source.Split(' ');
        }
    }
}