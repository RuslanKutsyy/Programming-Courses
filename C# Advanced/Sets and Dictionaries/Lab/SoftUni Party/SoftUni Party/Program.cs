using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            string command = Console.ReadLine();

            while (command != "PARTY")
            {
                guests.Add(command);
                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "END")
            {
                if (guests.Contains(command))
                {
                    guests.Remove(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);
            foreach (var name in guests)
            {
                Console.WriteLine(name);
            }
        }
    }
}
