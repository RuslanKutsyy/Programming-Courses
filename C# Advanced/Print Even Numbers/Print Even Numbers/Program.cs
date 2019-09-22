using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);
            var queue = new Queue<int>();
            string result = string.Empty;
            foreach (var num in numbers)
            {
                queue.Enqueue(num);
            }
            int turns = queue.Count();
            for (int i = 0; i < turns; i++)
            {
                int @integer = queue.Peek();
                if (@integer % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    queue.Dequeue();
                    queue.Enqueue(@integer);
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
