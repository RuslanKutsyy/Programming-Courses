using System;
using System.Linq;
using System.Collections.Generic;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var @char in input)
            {
                stack.Push(@char);
            }

            foreach (var @char in stack)
            {
                Console.Write(@char);
            }
        }
    }
}