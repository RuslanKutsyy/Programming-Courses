using System;
using System.Linq;
using System.Collections.Generic;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray().Reverse();
            int main = int.Parse(Console.ReadLine());
            Func<int, bool> divideByMain = x => x % main != 0;

            var newArr = numbers.Where(divideByMain);

            Console.WriteLine(string.Join(" ", newArr));
        }
    }
}
