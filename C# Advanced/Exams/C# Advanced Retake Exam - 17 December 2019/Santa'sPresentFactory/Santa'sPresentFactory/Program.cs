using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_sPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> materials = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> magic = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> toys = new Dictionary<string, int>
            {
                ["Doll"] = 0,
                ["Wooden train"] = 0,
                ["Teddy bear"] = 0,
                ["Bicycle"] = 0
            };

            while (true)
            {
                if (materials.Count == 0 || magic.Count == 0)
                {
                    break;
                }

                int materialItem = materials.Peek();
                int magicLevel = magic.Peek();

                int totalMagicLevel = materialItem * magicLevel;

                if ((materialItem == 0 || magicLevel == 0) || (materialItem == 0 && magicLevel == 0))
                {
                    if (materialItem == 0 && magicLevel == 0)
                    {
                        materials.Pop();
                        magic.Dequeue();
                        continue;
                    }

                    if (materialItem == 0 && magicLevel != 0)
                    {
                        materials.Pop();
                        continue;
                    }

                    if (magicLevel == 0 && materialItem != 0)
                    {
                        magic.Dequeue();
                        continue;
                    }
                }

                if (totalMagicLevel < 0)
                {
                    int sum = materialItem + magicLevel;
                    materials.Pop();
                    magic.Dequeue();
                    List<int> data = materials.ToList();
                    data.Reverse();
                    data.Add(sum);
                    materials = new Stack<int>(data);
                    continue;
                }

                if (totalMagicLevel == 150)
                {
                    toys["Doll"]++;
                    materials.Pop();
                    magic.Dequeue();
                    continue;
                }
                else if (totalMagicLevel == 250)
                {
                    toys["Wooden train"]++;
                    materials.Pop();
                    magic.Dequeue();
                    continue;
                }
                else if (totalMagicLevel == 300)
                {
                    toys["Teddy bear"]++;
                    materials.Pop();
                    magic.Dequeue();
                    continue;
                }
                else if (totalMagicLevel == 400)
                {
                    toys["Bicycle"]++;
                    materials.Pop();
                    magic.Dequeue();
                    continue;
                }
                else
                {
                    magic.Dequeue();
                    List<int> data = new List<int>(materials.ToList());
                    data[0] += 15;
                    data.Reverse();
                    materials = new Stack<int>(data);
                    continue;
                }
            }

            if ((toys["Doll"] >= 1 && toys["Wooden train"] >= 1) || (toys["Teddy bear"] >= 1 && toys["Bicycle"] >= 1))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magic.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }

            foreach (var item in toys.Where(x => x.Value >= 1).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
