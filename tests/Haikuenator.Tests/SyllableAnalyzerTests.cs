using System.Linq;
using NUnit.Framework;

namespace Haikuenator.Tests
{
    [TestFixture]
    public class SyllableAnalyzerTests
    {

        private static int GetSyllableCount(string word)
        {
            var analyzer = new SyllableAnalyzer(word);
            return analyzer.GetCount();
        }

        [Test]
        public void SyllableAnalyzerShouldSplitByVowel()
        {
            var analyzer = new SyllableAnalyzer("testing");
            var groups = analyzer.ParseVowelGroups().ToArray();
            Assert.AreEqual(new[] {"test", "ing"}, groups);
        }

        [Test]
        public void SyllableAnalyzerShouldCountBasicWordsCorrectly()
        {
            Assert.AreEqual(4, GetSyllableCount("fundamental"));
        }

        [Test]
        public void AnalyzerShouldDealWithWordsThatStartWithAVowel()
        {
            Assert.AreEqual(2, GetSyllableCount("open"));
        }

        [Test]
        public void AnalyzerShouldIgnoreSilentVowelsEndingWords()
        {
            Assert.AreEqual(1, GetSyllableCount("time"));
        }

    }
}