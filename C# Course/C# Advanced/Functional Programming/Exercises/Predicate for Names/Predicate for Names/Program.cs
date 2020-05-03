using System;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToArray();
            Predicate<string> check = x => x.Length <= nameLength;

            foreach (var name in names)
            {
                if (check(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
