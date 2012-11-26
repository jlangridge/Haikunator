using System.Linq;
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
            Assert.AreEqual("This is a test", WordTokenizer.Sanitize("This; is a, test."));
        }

        [Test]
        public void ToSanitizedStringShouldRemoveDigits()
        {
            Assert.AreEqual("This is a test", WordTokenizer.Sanitize("This2 is a, test."));
        }

        [Test]
        public void ToSanitizedStringShouldRemoveDuplicateSpaces()
        {
            Assert.AreEqual("This is a test", WordTokenizer.Sanitize("This   is a   test."));
        }
    }
}
