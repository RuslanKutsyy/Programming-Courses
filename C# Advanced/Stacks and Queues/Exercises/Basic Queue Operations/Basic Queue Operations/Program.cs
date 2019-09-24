using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numbersToPush = data[0];
            int numbersToPop = data[1];
            int mainNumber = data[2];
            int minValue = int.MaxValue;
            var queue = new Queue<int>();

            foreach (var item in numbers)
            {
                if (item <= minValue)
                {
                    minValue = item;
                }
                queue.Enqueue(item);
            }
            for (int i = 0; i < numbersToPop; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
            }
            if (queue.Count > 0)
            {
                if (queue.Contains(mainNumber))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(minValue);
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
