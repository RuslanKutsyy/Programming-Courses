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
            double tankCapacity = double.Parse(carData[3]);
            Car car = new Car(fuelQuantity, fuelConsumption, tankCapacity);

            var truckData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(truckData[1]);
            fuelConsumption = double.Parse(truckData[2]);
            tankCapacity = double.Parse(truckData[3]);
            Truck truck = new Truck(fuelQuantity, fuelConsumption, tankCapacity);

            var busData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            fuelQuantity = double.Parse(busData[1]);
            fuelConsumption = double.Parse(busData[2]);
            tankCapacity = double.Parse(busData[3]);
            Bus bus = new Bus(fuelQuantity, fuelConsumption, tankCapacity);

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
                        car.Drive(km);
                    }
                    else if (type == "Truck")
                    {
                        truck.Drive(km);
                    }
                    else if (type == "Bus")
                    {
                        bus.Drive(km);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    string type = cmd[1];
                    double km = double.Parse(cmd[2]);
                    if (type == "Bus")
                    {
                        bus.DriveEmpty(km);
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
                    else if (type == "Bus")
                    {
                        bus.Refuel(litters);
                    }
                }
            }

            //Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            //Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            //Console.WriteLine($"");

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}
