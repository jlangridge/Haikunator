using System.Linq;
using NUnit.Framework;

namespace Haikunator.Tests
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

        [Test]
        public void AnalyzerShouldCountDiphthongsAsASingleSyllable()
        {
            Assert.AreEqual(2, GetSyllableCount("output"));
            Assert.AreEqual(4, GetSyllableCount("undoubtedly"));
        }

        [Test]
        public void IsDiphthongShouldDetectDiphthongsCorrectly()
        {
            Assert.True(SyllableAnalyzer.IsDiphthong("oi"), "oi should be seen as a diphthong");
            Assert.False(SyllableAnalyzer.IsDiphthong("op"), "op should not be seen as a diphthong");
        }

        [Test]
        public void IsDiphthongShouldHandleSpecialCases()
        {
            Assert.False(SyllableAnalyzer.IsDiphthong("ia"), "ia should not be seen as a diphthong");
            Assert.False(SyllableAnalyzer.IsDiphthong("io"), "io should not be seen as a diphthong");
        }

        [Test]
        public void DoubleEsAtTheEndOfAWordShouldNotBeMarkedAsSilent()
        {
            Assert.AreEqual(3, GetSyllableCount("Yessiree"));
        }

        [Test]
        public void TrainShouldBeASingleSyllable()
        { 
            Assert.AreEqual(1, GetSyllableCount("train"));
        }

    }
}