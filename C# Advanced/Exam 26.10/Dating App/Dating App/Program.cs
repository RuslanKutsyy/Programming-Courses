using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var malesText = Console.ReadLine().Split().Select(int.Parse);
            var femalesText = Console.ReadLine().Split().Select(int.Parse);
            Queue<int> males = new Queue<int>(malesText.Reverse());
            Queue<int> females = new Queue<int>(femalesText);
            int matchCount = 0;

            while (males.Count != 0)
            {
                int currentMale = males.Peek();
                if (currentMale <= 0)
                {
                    males.Dequeue();
                    continue;
                }
                if (currentMale % 25 == 0)
                {
                    males.Dequeue();
                    if (males.Count != 0)
                    {
                        males.Dequeue();
                    }
                }
                if (females.Count != 0)
                {
                    int currentFemale = 0;
                    for (int j = 0; j < females.Count; j++)
                    {
                        if (j == 0)
                        {
                            currentFemale = females.Peek();
                        }
                        if (currentFemale <= 0)
                        {
                            females.Dequeue();
                            continue;
                        }
                        if (currentFemale % 25 == 0)
                        {
                            females.Dequeue();
                            if (females.Count != 0)
                            {
                                females.Dequeue();
                                break;
                            }
                        }
                        if (currentMale <= 0)
                        {
                            males.Dequeue();
                        }
                        if (currentMale == currentFemale)
                        {
                            males.Dequeue();
                            females.Dequeue();
                            matchCount++;
                            break;
                        }
                        else if (currentMale != currentFemale)
                        {
                            females.Dequeue();
                            currentMale /= 2;
                            males.Dequeue();
                            males.Enqueue(currentMale);
                            j = 0;
                        }
                    }
                }
                if (males.Count == 0 || females.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Matches: {matchCount}");
            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");

            }
            else
            {
                Console.WriteLine($"Males left: {males.Count}");
            }

            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
        }
    }
}
