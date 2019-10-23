using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                var data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (data.Length < 3)
                {
                    command = Console.ReadLine();
                    continue;
                }
                string cmd = data[0];
                string criteria1 = data[1];
                string criteria2 = data[2];

                if (cmd != "Remove" && cmd != "Double")
                {
                    command = Console.ReadLine();
                    continue;
                }
                Predicate<string> Filter = GetFilter(criteria1, criteria2);

                if (cmd == "Double")
                {
                    var tempList = new List<string>();

                    foreach (var name in guests)
                    {
                        tempList.Add(name);
                    }

                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (Filter(guests[i]))
                        {
                            tempList.Insert(i, guests[i]);
                        }
                    }
                    guests = tempList;
                }
                else if (cmd == "Remove")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (Filter(guests[i]))
                        {
                            guests.Remove(guests[i]);
                        }
                    }
                }
                else
                {
                    command = Console.ReadLine();
                    continue;
                }


                command = Console.ReadLine();
            }

            if (guests.Count > 0)
            {

                Console.WriteLine(String.Join(", ", guests.OrderBy(x => x)) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetFilter(string criteria1, string criteria2)
        {
            switch (criteria1)
            {
                case "StartsWith": return name => name.StartsWith(criteria2);
                case "Length":
                    {
                        bool validLength = int.TryParse(criteria2, out int lenght);
                        if (validLength)
                        {
                            return name => name.Length == lenght;
                        }
                        else
                        {
                            return name => false;
                        }
                    }
                case "EndsWith": return name => name.EndsWith(criteria2);
                default:
                    return name => false;
            }
        }
    }
}
