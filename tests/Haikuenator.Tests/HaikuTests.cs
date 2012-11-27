using System.IO;
using NUnit.Framework;

namespace Haikuenator.Tests
{
    [TestFixture]
    public class HaikuTests
    {
        [Test]
        public void CanReadShouldReturnTrueIfTheSuppliedLinesAreAHaiku()
        {
            var hk = new Haiku();
            Assert.True(hk.CanRead("An old silent pond... A frog jumps into the pond, splash! Silence again"));
            Assert.False(hk.CanRead("An old silent pond... A frogernator jumps into the pond, splash! Silence again"));
        }

        [Test]
        public void ReadFromShouldReturnAHaikuFromInputText()
        {
            var hk = new Haiku();
            hk.ReadFrom(new StringReader("An old silent pond... A frog jumps into the pond, splash! Silence again"));
            Assert.AreEqual("An old silent pond...\r\nA frog jumps into the pond,\r\nsplash! Silence again\r\n",
                hk.ToString());
        }
    }
}
