using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < num; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = input[0];
                var items = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                    for (int clothing = 0; clothing < items.Length; clothing++)
                    {
                        if (!wardrobe[color].ContainsKey(items[clothing]))
                        {
                            wardrobe[color].Add(items[clothing], 1);
                        }
                        else
                        {
                            wardrobe[color][items[clothing]]++;
                        }
                    }
                }
                else
                {
                    for (int clothing = 0; clothing < items.Length; clothing++)
                    {
                        if (!wardrobe[color].ContainsKey(items[clothing]))
                        {
                            wardrobe[color].Add(items[clothing], 1);
                        }
                        else
                        {
                            wardrobe[color][items[clothing]]++;
                        }
                    }

                }
            }

            var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string mainColor = data[0];
            string mainClothing = data[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                if (item.Key == mainColor)
                {
                    foreach (var cloth in item.Value)
                    {
                        Console.Write($"* {cloth.Key} - {cloth.Value}");
                        if (cloth.Key == mainClothing)
                        {
                            Console.Write(" (found!)");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    foreach(var cloth in item.Value)
                    {
                        Console.Write($"* {cloth.Key} - {cloth.Value}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
