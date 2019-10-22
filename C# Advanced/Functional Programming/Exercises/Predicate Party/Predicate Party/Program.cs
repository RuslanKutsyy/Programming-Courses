using System;
using System.Linq;
using System.Collections.Generic;

namespace Predicate_Party
{
    public class Guest
    {
        public string Name { get; set; }

        public Guest(string name)
        {
            this.Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                var data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string cmd = data[0];
                string criteria1 = data[1];
                string criteria2 = data[2];

                Predicate<string> Filter = GetFilter(criteria1, criteria2);
                

                if (command.StartsWith("Double"))
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
                            tempList.Insert(i+1, guests[i]);
                        }
                    }
                    guests = tempList;
                }
                if (command.StartsWith("Remove"))
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (Filter(guests[i]))
                        {
                            guests.Remove(guests[i]);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (guests.Count > 0)
            {

                Console.WriteLine(String.Join(", ", guests) + " are going to the party!");
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
                case "Length": return name => name.Length == int.Parse(criteria2);
                case "EndsWith": return name => name.EndsWith(criteria2);
                default:
                    return null;
            }
        }
    }
}
