using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haikuenator
{
    /// <summary>
    /// Represents a basic haiku, with a 5-7-5 syllable pattern
    /// </summary>
    public class Haiku
    {
        


        public IEnumerable<Line> Lines { get; private set; }

        public override string ToString()
        {
            return Lines.Aggregate(string.Empty, (current, line) => current + (line + Environment.NewLine));
        }

        public bool CanRead(string candidateText)
        {
            throw new NotImplementedException();
        }
    }
}
