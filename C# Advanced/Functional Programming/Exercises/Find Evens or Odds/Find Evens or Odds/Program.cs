using System;
using System.Linq;
using System.Collections.Generic;


namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lowerBound = data[0];
            int upperBound = data[1];
            string command = Console.ReadLine();
            Predicate<int> IsEven = x => x % 2 == 0;

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (command == "even" && IsEven(i))
                {
                    Console.Write(i + " ");
                }
                else if (command == "odd" && !IsEven(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
