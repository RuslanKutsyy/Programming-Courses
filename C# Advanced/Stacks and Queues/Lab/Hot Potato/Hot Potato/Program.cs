using System;
using System.Linq;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split();
            int count = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(names);

            while (queue.Count>1)
            {
                for (int i = 1; i <= count; i++)
                {
                    if (i!=count)
                    {
                        string name = queue.Dequeue();
                        queue.Enqueue(name);
                    }
                    else
                    {
                        string name = queue.Dequeue();
                        Console.WriteLine($"Removed {name}");
                    }
                }
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
