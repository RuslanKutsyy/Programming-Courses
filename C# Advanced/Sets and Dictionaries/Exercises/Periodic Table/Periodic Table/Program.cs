using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                var data = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < data.Length; j++)
                {
                    elements.Add(data[j]);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));

        }
    }
}
