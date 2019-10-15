using System;
using System.Linq;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            HashSet<string> cars = new HashSet<string>();

            while (command != "END")
            {
                var data = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string direction = data[0];
                string carNumber = data[1];

                if (direction == "IN")
                {
                    if (!cars.Contains(carNumber))
                    {
                        cars.Add(carNumber);
                    }
                }
                else if (direction == "OUT")
                {
                    if (cars.Contains(carNumber))
                    {
                        cars.Remove(carNumber);
                    }
                }

                command = Console.ReadLine();
            }

            if (cars.Count > 0)
            {
                foreach (var carNumber in cars)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
