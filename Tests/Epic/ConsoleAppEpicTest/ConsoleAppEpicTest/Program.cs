using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleAppEpicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string text="", file;
            if (args.Length == 0)
            {
                file = "Alice.txt";
                
            }
            else
            {
                file = args[0];                           
            }
            if (File.Exists(file))
            {
                text = File.ReadAllText("Alice.txt");
                //Console.Write(text);
            }
            else
            {
                Console.Write("File not found! Please try again...");
            }
            var cleanText = text.Replace("\r\n", " ");
            string[] words = cleanText.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

            //Console.Write(words);

            var frequencyList = new Dictionary<string, int>();

            foreach (var word in words)
                if (!word.Contains("a") && !word.Contains("the") && !word.Contains("in")
                    && !word.Contains("on") && !word.Contains("an") && !word.Contains("and"))
                {
                    if (frequencyList.ContainsKey(word))
                        frequencyList[word]++;
                    else
                        frequencyList[word] = 1;
                }


            var sortedDict = frequencyList.OrderByDescending(pair => pair.Value).Take(10);
            //var sortedDict2 = (from entry in frequencyList
            //orderby entry.Value descending
            //select entry).Take(10);

            foreach (var item in sortedDict)
                Console.WriteLine(String.Format("{0} - {1}", item.Key, item.Value));

            Console.ReadKey();
        }
    }
}
