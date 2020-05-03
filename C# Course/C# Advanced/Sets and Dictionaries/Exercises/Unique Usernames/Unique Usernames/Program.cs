using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int names = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < names; i++)
            {
                string name = Console.ReadLine();
                usernames.Add(name);
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
