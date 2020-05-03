using System;
using System.Collections.Generic;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var numbers = Console.ReadLine().Split();
            int numberOfElements = int.Parse(input[0]);
            int elementsToPop = int.Parse(input[1]);
            int xInteger = int.Parse(input[2]);
            var stack = new Stack<int>();
            int smallest = int.MaxValue;

            for (int i = 0; i < numberOfElements; i++)
            {
                int num = int.Parse(numbers[i]);
                if (num < smallest)
                {
                    smallest = num;
                }
                stack.Push(num);
            }
            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
                if (stack.Count == 0)
                {
                    break;
                }
            }
            if (stack.Count != 0)
            {
                if (stack.Contains(xInteger))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(smallest);
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
