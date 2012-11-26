using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Haikuenator.Tests
{
    [TestFixture]
    public class WordTokenizerTests
    {
        [Test]
        public void TokenizerShouldTokenizeWordsBySpaces()
        {
            var tokenizer = new WordTokenizer("This is a test");
            var results = tokenizer.ParseTokens().ToArray();
            Assert.AreEqual(new[]{"This", "is", "a", "test"}, results);
        }
    }
}
