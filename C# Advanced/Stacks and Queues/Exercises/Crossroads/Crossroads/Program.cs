using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            string input = Console.ReadLine();
            string stop = "END";
            bool crashed = false;
            string crashedLetter = string.Empty;
            int carCounter = 0;

            while (true)
            {
                if (input == stop)
                {
                    break;
                }
                else if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else if (input == "green")
                {
                    string car = queue.Dequeue();
                    carCounter++;
                    var tempQueue = new Queue<char>(car);
                    int genTime = greenLightDuration + freeWindow;
                    for (int i = 0; i < genTime; i++)
                    {
                        if (tempQueue.Count == 0)
                        {
                            break;
                        }
                        tempQueue.Dequeue();
                    }
                    if (tempQueue.Count > 0)
                    {
                        crashed = true;
                        crashedLetter += tempQueue.Peek();
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{car} was hit at {crashedLetter}.");
                        break;
                    }
                }
                
                input = Console.ReadLine();
            }
            if (!crashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carCounter} total cars passed the crossroads.");
            }
        }
    }
}
