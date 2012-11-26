using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Haikuenator.Tests
{
    [TestFixture]
    public class SyllableAnalyzerTests
    {
        [Test]
        public void SyllableAnalyzerShouldSplitByVowel()
        {
            var analyzer = new SyllableAnalyzer("testing");
            var groups = analyzer.ParseVowelGroups().ToArray();
            Assert.AreEqual(new[]{"test", "ing"}, groups);
        }

        [Test]
        public void SyllableAnalyzerShouldCountBasicWordsCorrectly()
        {
            var analyzer = new SyllableAnalyzer("fundamental");
            Assert.AreEqual(4, analyzer.GetCount());
        }
    }
}
