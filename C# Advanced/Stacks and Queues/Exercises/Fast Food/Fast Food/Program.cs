using System;
using System.Collections.Generic;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split();
            int biggestOrder = int.MinValue;
            var queue = new Queue<int>();

            foreach (var item in input)
            {
                int num = int.Parse(item);
                if (num >= biggestOrder)
                {
                    biggestOrder = num;
                }
                queue.Enqueue(num);
            }
            Console.WriteLine(biggestOrder);

            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("Orders complete");
                    break;
                }
                int num = queue.Peek();
                if (num <= quantity)
                {
                    queue.Dequeue();
                    quantity -= num;
                }
                else
                {
                    Console.WriteLine($"Orders left: {String.Join(" ", queue)}");
                    break;
                }
            }
        }
    }
}