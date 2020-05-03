using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var newNums = numbers.OrderBy(x => x).Where(x => x % 2 == 0);

            Console.WriteLine(string.Join(", ", newNums));
        }
    }
}
