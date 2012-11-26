using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Haikuenator
{
    /// <summary>
    /// Represents a basic haiku, with a 5-7-5 syllable pattern
    /// </summary>
    public class Haiku
    {
        
        public Haiku()
        {
            Lines = new List<Line> {new Line(5), new Line(7), new Line(5)};
        }

        public IEnumerable<Line> Lines { get; private set; }

        public override string ToString()
        {
            return Lines.Aggregate(string.Empty, (current, line) => current + (line + Environment.NewLine));
        }

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
