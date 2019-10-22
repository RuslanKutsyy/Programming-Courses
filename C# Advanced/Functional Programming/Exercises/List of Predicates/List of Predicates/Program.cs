using System;
using System.Linq;
using System.Collections.Generic;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, bool> check = x =>
            {
                int count = 0;
                for (int i = 0; i < dividers.Length; i++)
                {
                    if (x % dividers[i] == 0)
                    {
                        count++;
                    }
                }
                if (count == dividers.Length)
                {
                    return true;
                }
                else
                    return false;
            };

            for (int i = 1; i <= num; i++)
            {
                if (check(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
