using System;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToArray();
            Action<string> Append = name => Console.WriteLine($"Sir {name}");

            for (int i = 0; i < names.Length; i++)
            {
                Append(names[i]);
            }
        }
    }
}
