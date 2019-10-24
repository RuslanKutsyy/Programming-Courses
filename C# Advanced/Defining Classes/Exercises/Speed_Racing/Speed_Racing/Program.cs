using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < num; i++)
            {
                var data = Console.ReadLine().Split();
                string model = data[0];
                double fuelAmount = double.Parse(data[1]);
                double fuelConsumptionFor1km = double.Parse(data[2]);

                Car car = new Car(model, fuelAmount, fuelAmount, 0);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                var data = command.Split();
                string carModel = data[1];
                double distance = double.Parse(data[2]);
                Car tempCar = cars.Where(x => x.Model == carModel).First();
                Car.Drive();
                command = Console.ReadLine();
            }
            
        }
    }
}
