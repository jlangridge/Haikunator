using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Haikuenator.Tests
{
    [TestFixture]
    public class LineTests
    {
        [Test]
        public void CanReadShouldReturnTrueIfTheNumberOfSyllablesIsPresent()
        {
            var line = new Line(5);
            Assert.True(line.CanRead("out of the water"));
        }

        [Test]
        public void CanReadShouldReturnTrueIfTheNumberOfSyllablesCannotBeRepresented()
        {
            var line = new Line(5);
            Assert.False(line.CanRead("out of itself"));
        }
    }
}
