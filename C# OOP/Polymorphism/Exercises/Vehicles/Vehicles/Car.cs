using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car
    {
        public double TankCapacity { get; }
        private double fuelQuantity;
        public double FuelConsumption { get; }

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity <= tankCapacity)
            {
                this.fuelQuantity = fuelQuantity;
            }
            else
            {
                this.FuelQuantity = 0;
            }
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value <= this.TankCapacity)
                {
                    this.fuelQuantity = value;
                }
                else
                {
                    this.fuelQuantity = 0;
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

        public override string ToString()
        {
            return $"{base.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
