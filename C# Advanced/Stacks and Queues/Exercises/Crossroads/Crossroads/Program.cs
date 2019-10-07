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
            bool toEnd = false;
            int carCounter = 0;

            while (input != stop)
            {
                if (input != "green")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    if (queue.Count == 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    string car = queue.Dequeue();
                    if (car == "")
                    {
                        while (car.Length == 0)
                        {
                            car = queue.Dequeue();
                        }
                    }
                    var tempQueue = new Queue<char>(car.ToCharArray());
                    carCounter++;

                    for (int i = 1; i <= greenLightDuration; i++)
                    {

                        if (queue.Count != 0 && tempQueue.Count == 0)
                        {
                            car = queue.Dequeue();
                            if (car != "")
                            {
                                carCounter++;
                                foreach (var @char in car)
                                {
                                    tempQueue.Enqueue(@char);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else if (queue.Count == 0 && tempQueue.Count == 0)
                        {
                            break;
                        }
                        tempQueue.Dequeue();
                    }
                    if (tempQueue.Count != 0)
                    {
                        for (int j = 1; j <= freeWindow; j++)
                        {
                            tempQueue.Dequeue();
                            if (j == freeWindow && tempQueue.Count != 0)
                            {
                                carCounter -= 1;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {tempQueue.Peek()}.");
                                return;
                            }
                            else if (tempQueue.Count == 0)
                            {
                                toEnd = true;
                                break;
                            }
                        }
                    }
                }
                if (!toEnd)
                {
                    input = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carCounter} total cars passed the crossroads.");
        }
    }
}
