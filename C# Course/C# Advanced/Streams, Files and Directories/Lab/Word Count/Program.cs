using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = new List<string>();
            string[] words;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (var reader = new StreamReader(Environment.CurrentDirectory + "\\Input.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] separators = { ",", "!", ".", "?", "-", " ", ""};
                    var input = line.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    foreach (var item in input)
                    {
                        text.Add(item);
                    }
                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader(Environment.CurrentDirectory + "\\words.txt"))
            {
                var line = reader.ReadLine().ToLower().Split().ToArray();

                foreach (var item in line)
                {
                    dict.Add(item, 0);
                }

                for (int i = 0; i < line.Length; i++)
                {
                    string word = line[i];

                    for (int j = 0; j < text.Count; j++)
                    {
                        if (text[j] == word)
                        {
                            dict[word]++;
                        }
                    }
                }
            }

            foreach (var item in dict.OrderByDescending(x =>x.Value))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

        }
    }
}
