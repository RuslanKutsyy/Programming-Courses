using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; }

        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public virtual void DriveCar(double km)
        {
            double neededFuel = (this.FuelConsumption + 0.9) * km;

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

        public virtual void Refuel(double litters)
        {
            this.FuelQuantity += litters;
        }
    }
}
