using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(numbers);
            string command = Console.ReadLine().ToLower();

            while (true)
            {
                string[] cmd = command.Split();
                if (command.StartsWith("end"))
                {
                    Console.WriteLine("Sum: " + stack.Sum());
                    break;
                }
                else if (command.StartsWith("add "))
                {
                    int num1 = int.Parse(cmd[1]);
                    int num2 = int.Parse(cmd[2]);

                    stack.Push(num1);
                    stack.Push(num2);
                }
                else if (command.StartsWith("remove"))
                {
                    int removeCount = int.Parse(cmd[1]);

                    if (stack.Count>removeCount)
                    {
                        for (int i = 0; i < removeCount; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
        }
    }
}
