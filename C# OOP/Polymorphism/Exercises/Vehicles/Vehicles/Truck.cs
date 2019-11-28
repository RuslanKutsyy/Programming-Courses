using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Car
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override void DriveCar(double km)
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
            this.FuelQuantity += litters * 0.95;
        }
    }
}
