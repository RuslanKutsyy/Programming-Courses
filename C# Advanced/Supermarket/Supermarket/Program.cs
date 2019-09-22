using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string stopWord = "End";
            var queue = new Queue<string>();

            while (true)
            {
                if (input == stopWord)
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    break;
                }
                else
                {
                    if (input != "Paid")
                    {
                        queue.Enqueue(input);
                    }
                    else
                    {
                        int count = queue.Count;
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(queue.Dequeue());
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
