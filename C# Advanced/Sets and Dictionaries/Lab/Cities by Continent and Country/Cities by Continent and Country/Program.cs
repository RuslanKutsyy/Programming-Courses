using System;
using System.Linq;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> countryDatabase = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string continent = command[0];
                string country = command[1];
                string city = command[2];

                if (!countryDatabase.ContainsKey(continent))
                {
                    countryDatabase.Add(continent, new Dictionary<string, List<string>>());
                    countryDatabase[continent].Add(country, new List<string>());
                    countryDatabase[continent][country].Add(city);
                }
                else
                {
                    if (!countryDatabase[continent].ContainsKey(country))
                    {
                        countryDatabase[continent].Add(country, new List<string>());
                        countryDatabase[continent][country].Add(city);
                    }
                    else
                    {
                        countryDatabase[continent][country].Add(city);
                    }
                }
            }

            foreach (var continent in countryDatabase)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write("\t" + $"{country.Key} -> {String.Join(", ", country.Value)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
