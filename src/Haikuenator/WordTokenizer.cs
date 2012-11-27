using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Haikuenator
{
    /// <summary>
    /// Imperfect (good-enough?) implementation of a lexical tokenizer.
    /// Not really suitable for anything other than a bit of fun..
    /// </summary>
    public class WordTokenizer
    {
        private readonly TextReader Source;


        /// <summary>
        /// Initializes a new instance of the <see cref="WordTokenizer"/> class
        /// </summary>
        /// <param name="source">The source of words to tokenize</param>
        public WordTokenizer(TextReader source)
        {
            Source = source;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordTokenizer"/> class
        /// </summary>
        /// <param name="source">The source of words to tokenize</param>
        public WordTokenizer(string source) : this(new StringReader(source))
        {
            
        }

        /// <summary>
        /// Sanitizes a string for use with the <see cref="SyllableAnalyzer"/>. This means removing
        /// punctuation and digits etc.
        /// </summary>
        /// <param name="source">The source string to sanitize</param>
        /// <returns>The sanitized string</returns>
        public static string Sanitize(string source)
        {
            if(source == null)
            {
                throw new ArgumentNullException("source");
            }
            var punctuationRemoved = Regex.Replace(source, @"[^A-Za-z ]", string.Empty);
            return Regex.Replace(punctuationRemoved, @"\s+", " ");
        }


        /// <summary>
        /// Parse tokens from the <see cref="Source"/> string
        /// </summary>
        /// <returns>Each parsed token</returns>
        public IEnumerable<string> GetTokens()
        {
            string token;
            while((token = NextToken())!= null)
            {
                yield return token;
            }
        }

        /// <summary>
        /// Consume the next token from the input stream
        /// </summary>
        /// <returns>The sanitized token</returns>
        public string NextToken()
        {
            int c;
            string token = null;
            while((c=Source.Read()) != -1)
            {
                if((char)c==' ' && !string.IsNullOrEmpty(token))
                {
                    break;
                }
                token += (char)c;
            }

            return token;
        }
    }
}