using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            string[] input = new string[3];
            int tank = 0;
            int winner;
            int count = 0;
            int oil = 0;
            int distance = 0;
            int swapCount = 0;
            bool swapped = false;

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Console.ReadLine();
            }

            var queue = new Queue<string>(input);
            while (true)
            {
                if (swapCount >= pumps)
                {
                    swapped = true;
                    break;
                }
                string Start = queue.Peek();
                var data = Start.Split();
                oil = int.Parse(data[0]);
                distance = int.Parse(data[1]);
                tank += oil;
                if (tank - distance >= 0 )
                {
                    tank -= distance;
                    queue.Dequeue();
                    queue.Enqueue(Start);
                    swapCount++;
                    count++;
                    if (count == pumps)
                    {
                        break;
                    }
                }
                else
                {
                    tank = 0;
                    queue.Dequeue();
                    queue.Enqueue(Start);
                    swapCount++;
                    count = 0;
                }
            }
            if (!swapped)
            {
                winner = Array.IndexOf(input, queue.Peek());
                Console.WriteLine(winner);
            }
            else
            {
                return;
            }
        }
    }
}