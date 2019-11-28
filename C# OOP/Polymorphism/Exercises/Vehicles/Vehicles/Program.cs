using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double fuelQuantity = double.Parse(carData[1]);
            double fuelConsumption = double.Parse(carData[2]);
            Car car = new Car(fuelQuantity, fuelConsumption);

            var truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(truckData[1]);
            fuelConsumption = double.Parse(truckData[2]);
            Truck truck = new Truck(fuelQuantity, fuelConsumption);

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = cmd[0];

                if (command == "Drive")
                {
                    string type = cmd[1];
                    double km = double.Parse(cmd[2]);

                    if (type == "Car")
                    {
                        car.DriveCar(km);
                    }
                    else if (type == "Truck")
                    {
                        truck.DriveCar(km);
                    }
                }
                else if (command == "Refuel")
                {
                    string type = cmd[1];
                    double litters = double.Parse(cmd[2]);

                    if (type == "Car")
                    {
                        car.Refuel(litters);
                    }
                    else if (type == "Truck")
                    {
                        truck.Refuel(litters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
