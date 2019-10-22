using System;
using System.IO;
using System.Linq;

namespace Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split().ToArray();

            Action<string> Printer = x => Console.WriteLine(x);

            for (int i = 0; i < words.Length; i++)
            {
                Printer(words[i]);
            }
        }
    }
}
