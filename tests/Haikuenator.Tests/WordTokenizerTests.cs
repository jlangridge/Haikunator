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

        [Test]
        public void TokenizerShouldNotIncludeCommonPunctuation()
        {
            var tokenizer = new WordTokenizer("This; is a, test.");
            var results = tokenizer.ParseTokens().ToArray();
            Assert.AreEqual(new[] { "This", "is", "a", "test" }, results);
        }

        [Test]
        public void ToSanitizedStringShouldRemovePunctuation()
        {
            var tokenizer = new WordTokenizer("This; is a, test.");
            Assert.AreEqual("This is a test", tokenizer.GetSanitizedString());
        }

        [Test]
        public void ToSanitizedStringShouldRemoveDigits()
        {
            var tokenizer = new WordTokenizer("This2 is a, test.");
            Assert.AreEqual("This is a test", tokenizer.GetSanitizedString());
        }

        [Test]
        public void ToSanitizedStringShouldRemoveDuplicateSpaces()
        {
            var tokenizer = new WordTokenizer("This   is a   test.");
            Assert.AreEqual("This is a test", tokenizer.GetSanitizedString());
        }
    }
}
