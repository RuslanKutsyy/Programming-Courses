using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().ToCharArray();
            Dictionary<char, int> results = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (!results.ContainsKey(words[i]))
                {
                    results.Add(words[i], 1);
                }
                else
                {
                    results[words[i]]++;
                }
            }

            foreach (var item in results.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
