using System;
using System.Collections.Generic;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (numberOfQueries >= 1 & numberOfQueries <= 105)
            {

                for (int i = 0; i < numberOfQueries; i++)
                {
                    string[] command = Console.ReadLine().Split();
                    string cmd = command[0];

                    switch (cmd)
                    {
                        case "1":
                            {
                                int numToPush = int.Parse(command[1]);
                                if (numToPush >= 1 && numToPush <= 109)
                                {
                                    stack.Push(int.Parse(command[1]));
                                }
                                break;
                            }
                        case "2":
                            {
                                if (stack.Count > 0)
                                {
                                    stack.Pop();
                                }
                                break;
                            }
                        case "3":
                            {
                                int maxValue = int.MinValue;
                                foreach (var item in stack)
                                {
                                    if (item > maxValue)
                                    {
                                        maxValue = item;
                                    }
                                }
                                Console.WriteLine(maxValue);
                                break;
                            }
                        case "4":
                            {
                                int minValue = int.MaxValue;
                                foreach (var item in stack)
                                {
                                    if (item < minValue)
                                    {
                                        minValue = item;
                                    }
                                }
                                Console.WriteLine(minValue);
                                break;
                            }
                        default:
                            break;
                    }
                }
                Console.WriteLine(string.Join(", ", stack));
            }
        }
    }
}
