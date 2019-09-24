using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            int minValue = int.MaxValue;
            int numsToPush = data[0];
            int numbersToPop = data[1];
            int mainNum = data[2];

            for (int i = 0; i < numsToPush; i++)
            {
                int number = numbers[i];
                if (number < minValue)
                {
                    minValue = number;
                }
                stack.Push(number);
            }
            for (int i = 0; i < numbersToPop; i++)
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            if (stack.Count > 0)
            {
                if (stack.Contains(mainNum))
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
