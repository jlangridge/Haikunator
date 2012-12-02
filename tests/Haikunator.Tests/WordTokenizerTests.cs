using System;
using System.IO;
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
            var results = tokenizer.GetTokens().ToArray();
            Assert.AreEqual(new[]{"This", "is", "a", "test"}, results);
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

        [Test]
        public void NextTokenShouldReadThroughATextReaderOneWordAtATime()
        {
            var reader = new StringReader("This is a test");
            var tokenizer = new WordTokenizer(reader);
            var word = tokenizer.NextToken();
            Assert.AreEqual("This", word);
            Assert.True(reader.Peek() == 'i');
        }

        [Test]
        public void NextTokenShouldReturnNullWhenThereAreNoMoreTokens()
        {
            var tokenizer = new WordTokenizer("This");
            tokenizer.NextToken();
            Assert.IsNull(tokenizer.NextToken());
        }

        [Test]
        public void SanitizeShouldThrowArgumentNullExceptionWhenNullIsPassedIn()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => WordTokenizer.Sanitize(null));
            Assert.AreEqual("source", ex.ParamName);
        }
    }
}
