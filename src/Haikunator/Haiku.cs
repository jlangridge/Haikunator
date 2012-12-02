using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Haikunator
{
    /// <summary>
    /// Represents a basic haiku, with a 5-7-5 syllable pattern by default
    /// </summary>
    public class Haiku
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Haiku"/> class
        /// </summary>
        /// <param name="lineLengths">The lengths of the lines, in syllables</param>
        public Haiku(params int[] lineLengths)
        {
            Lines = lineLengths.Select(lineLength => new Line(lineLength)).ToList();
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="Haiku"/> class with 
        /// the default 5-7-5 pattern
        /// </summary>
        public Haiku() : this(5, 7, 5)
        {
        }


        /// <summary>
        /// Collection of <see cref="Lines"/> that go to make up the Haiku
        /// </summary>
        public IEnumerable<Line> Lines { get; private set; }

        public override string ToString()
        {
            return Lines.Aggregate(string.Empty, (current, line) => current + (line + Environment.NewLine));
        }

        /// <summary>
        /// Asseses whether the supplied text will fit correctly into the <see cref="Haiku"/>
        /// </summary>
        /// <param name="candidateText">The text to test</param>
        /// <returns>True if the syllables will fit, otherwise false</returns>
        public bool CanRead(string candidateText)
        {
            var reader = new StringReader(candidateText);
            foreach (var line in Lines)
            {
                try
                {
                    var testLine = new Line(line.Syllables);
                    testLine.ReadFrom(reader);    
                }
                catch(ArgumentException)
                {
                    return false;
                }
                
            }
            return true;
        }

        public void ReadFrom(TextReader reader)
        {
            foreach (var line in Lines)
            {
                line.ReadFrom(reader);
            }
            
        }
    }
}
