using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carNum = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string stopWord = "end";
            var queue = new Queue<string>();
            int carsCount = 0;

            while (input != stopWord)
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    for (int i = 0; i < carNum; i++)
                    {
                        if (queue.Count==0)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        carsCount++;
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{carsCount} cars passed the crossroads.");
        }
    }
}
