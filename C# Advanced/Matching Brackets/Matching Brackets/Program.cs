using System;
using System.Linq;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stackForOpenBrackets = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stackForOpenBrackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = stackForOpenBrackets.Pop();
                    int endIndex = i;
                    Console.WriteLine($"{input.Substring(startIndex, i - startIndex + 1)}");
                }
            }
        }
    }
}
