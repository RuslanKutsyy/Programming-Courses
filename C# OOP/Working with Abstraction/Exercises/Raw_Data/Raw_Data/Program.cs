using System;
using System.Collections.Generic;
using System.Linq;

namespace Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var data = Console.ReadLine().Split().ToArray();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age,
                    tire4Pressure, tire4Age);
                cars.Add(car);
            }

            GerFilteredCars(cars, Console.ReadLine());
        }

        static void GerFilteredCars(List<Car> cars, string filter)
        {
            List<Car> filteredList = new List<Car>();
            if (filter == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.CargoType == filter)
                    {
                        for (int i = 0; i < car.Tires.Length; i++)
                        {
                            if (car.Tires[i].TirePressure < 1)
                            {
                                filteredList.Add(car);
                                break;
                            }
                        }
                    }
                }
            }
            else if (filter == "flamable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.CargoType == filter && car.Engine.EnginePower > 250)
                    {
                        filteredList.Add(car);
                    }
                }
            }

            foreach (var car in filteredList)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
