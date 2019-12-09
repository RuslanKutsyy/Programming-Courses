using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> items = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> materials = new Dictionary<string, int>
            {
                ["Glass"] = 0,
                ["Aluminium"] = 0,
                ["Lithium"] = 0,
                ["Carbon fiber"] = 0
            };

            while (true)
            {
                if (liquids.Count == 0 || items.Count == 0)
                {
                    break;
                }

                int liquid = liquids.Peek();
                int physItem = items.Peek();

                if (liquid + physItem == 25)
                {
                    materials["Glass"]++;

                    liquids.Dequeue();
                    items.Pop();
                }
                else if (liquid + physItem == 50)
                {
                    materials["Aluminium"]++;

                    liquids.Dequeue();
                    items.Pop();
                }
                else if (liquid + physItem == 75)
                {
                    materials["Lithium"]++;

                    liquids.Dequeue();
                    items.Pop();
                }
                else if (liquid + physItem == 100)
                {
                    materials["Carbon fiber"]++;

                    liquids.Dequeue();
                    items.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    physItem += 3;
                    items.Pop();
                    List<int> temp = items.ToList();
                    temp.Insert(0, physItem);
                    items = new Stack<int>(temp.ToArray().Reverse());
                }
            }

            if (!materials.ContainsValue(0))
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if (liquids.Count > 0)
            {
                Console.WriteLine("Liquids left: " + string.Join(", ", liquids));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (items.Count > 0)
            {
                Console.WriteLine("Physical items left: " + string.Join(", ", items));
            }
            else
            {
                Console.WriteLine("Physical items left: none");
            }

            foreach (var item in materials.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
