using System;
using System.Collections.Generic;
using System.IO;
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

        [Test]
        public void ReadFromShouldConsumeTheCorrectNumberOfSyllablesFromTheInput()
        {
            var input = new StringReader("out of the water out of itself");
            var line = new Line(5);
            line.ReadFrom(input);
            Assert.AreEqual("out of the water", line.ToString());
            Assert.AreEqual("out of itself", input.ReadToEnd());
        }

        [Test]
        public void LinesThatAreTooShortShouldThrowAnArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Line(5).ReadFrom(new StringReader("Not long enough")));
            Assert.AreEqual("input", ex.ParamName);
        }
    }
}
