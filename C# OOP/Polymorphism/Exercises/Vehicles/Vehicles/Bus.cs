using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Car
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override void Drive(double km)
        {
            double neededFuel = (this.FuelConsumption + 1.4) * km;

            CheckAndPrint(neededFuel, km);
        }

        public void DriveEmpty(double km)
        {
            double neededFuel = this.FuelConsumption * km;

            CheckAndPrint(neededFuel, km);
        }

        public override void Refuel(double litters)
        {
            base.Refuel(litters);
        }

        private void CheckAndPrint(double neededFuel, double km)
        {
            if (neededFuel < this.FuelQuantity)
            {
                this.FuelQuantity -= neededFuel;
                Console.WriteLine($"Car travelled {km} km");
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }
    }
}
