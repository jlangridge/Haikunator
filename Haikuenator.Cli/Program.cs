using System;
using System.IO;

namespace Haikuenator.Cli
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Haiku.......");
            using(var reader = File.OpenText("HaikuTest.txt"))
            {
                while(!reader.EndOfStream)
                {
                    var hk = new Haiku();
                    
                    try
                    {
                        
                        hk.ReadFrom(reader);
                        Console.WriteLine(hk);
                        Console.WriteLine("======================");
                        
                        Console.Read();
                    }
                    catch (ArgumentException)
                    {
                        //Um, yeah... this is quick & dirty test code
                    }

                    var tokenizer = new WordTokenizer(reader);
                    tokenizer.NextToken();
                }
                
            }
            Console.Read();
        }
    }
}
