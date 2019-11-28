using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Car
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double km)
        {
            double neededFuel = (this.FuelConsumption + 1.6) * km;

            if (neededFuel < this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Truck travelled {km} km");
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double litters)
        {
            if (litters > 0)
            {
                this.FuelQuantity += litters * 0.95;
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
        }
    }
}
