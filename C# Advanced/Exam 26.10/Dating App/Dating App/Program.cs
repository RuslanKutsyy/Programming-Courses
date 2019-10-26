using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var maleText = Console.ReadLine().Split().Select(int.Parse);
            var femaleText = Console.ReadLine().Split().Select(int.Parse);
            Queue<int> males = new Queue<int>();
            Queue<int> females = new Queue<int>();
            int matchCount = 0;

            foreach (var item in maleText.Reverse())
            {
                males.Enqueue(item);
            }
            foreach (var item in femaleText)
            {
                females.Enqueue(item);
            }

            while (males.Count != 0 && females.Count != 0)
            {
                int currentFemale = females.Peek();

                if (currentFemale == 0 || currentFemale % 25 == 0)
                {
                    females.Dequeue();

                    if (currentFemale % 25 == 0 && currentFemale != 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }

                for (int i = 0; i < males.Count; i++)
                {
                    int currentMale = males.Peek();

                    if (currentMale == 0 || currentMale % 25 == 0)
                    {
                        males.Dequeue();
                        if ((double)currentMale % 25 == 0 && currentMale != 0)
                        {
                            males.Dequeue();
                        }
                        i = -1;
                        continue;
                    }

                    if (currentFemale == currentMale)
                    {
                        matchCount++;
                        females.Dequeue();
                        males.Dequeue();
                        break;
                    }
                    else
                    {
                        females.Dequeue();
                        males.Dequeue();
                        males.Enqueue(currentMale / 2);
                        Queue<int> temp = males;
                        males = new Queue<int>();
                        foreach (var item in temp.Reverse())
                        {
                            males.Enqueue(item);
                        }
                        break;
                    }
                }
            }

            Console.WriteLine($"Matches: {matchCount}");
            if (males.Count != 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine($"Males left: none");
            }

            if (females.Count != 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
