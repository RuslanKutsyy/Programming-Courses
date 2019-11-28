using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car
    {
        private double tankCapacity;
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; }

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            set
            {
                if (value <= tankCapacity)
                {
                    this.tankCapacity = value;
                }
                else
                {
                    this.tankCapacity = 0;
                }
            }
        }

        public virtual void Drive(double km)
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
            if (litters > 0)
            {
                if (this.FuelQuantity + litters <= this.TankCapacity)
                {
                    this.FuelQuantity += litters;
                }
                else
                {
                    Console.WriteLine($"Cannot fit {litters} fuel in the tank");
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            
        }
    }
}
