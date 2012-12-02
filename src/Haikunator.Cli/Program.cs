using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Haikuenator.Cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if(args.Length < 1 || args.Length> 2)
            {
                ShowUsage();
                Environment.Exit(1);
            }

            var username = args[0];

            LinePattern pattern;

            if(args.Length > 1)
            {
               pattern = LinePattern.Parse(args[1]);
            }
            else
            {
                pattern = LinePattern.Default;
            }
            

            Console.WriteLine("Haikuenifying {0}...", username);
            Console.WriteLine("------------------------------------------");

            var statuses = LoadStatuses(username);
            foreach (var status in statuses)
            {
                var hk = pattern.CreateHaiku();
                try
                {
                    hk.ReadFrom(new StringReader(status));    
                    Console.WriteLine(hk);
                    Console.WriteLine("===============================");
                }
                catch(ArgumentException)
                {
                    
                }

            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Haikuenates twitter feeds (kind of)");
            Console.WriteLine("Usage: Haikuenate [screen name] [pattern]");
            Console.WriteLine("That is all.");
        }

        public static IEnumerable<string> LoadStatuses(string username)
        {
            var urlString = string.Format(
                "http://api.twitter.com/1/statuses/user_timeline.xml?screen_name={0}&count=100", username);
            var client = new WebClient();

            var xmlStatuses = client.DownloadString(new Uri(urlString));

            var xmlTweets = XElement.Parse(xmlStatuses); 

            return from tweet in xmlTweets.Descendants("status")
                          select (string)tweet.Element("text");
        }
    }
}
