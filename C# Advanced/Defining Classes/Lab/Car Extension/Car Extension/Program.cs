using System;

namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public Car()
        {
        }

        public void Drive(double distance)
        {
            double expenceFuel = FuelConsumption * distance / 100;
            if (expenceFuel > this.FuelQuantity )
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity = distance / 100 * this.FuelConsumption;
            }
        }

        public string WhoAmI()
        {
            string text = $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
            return text;
        }
    }
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car
            {
                Make = "VW",
                Model = "MK3",
                Year = 1992,
                FuelQuantity = 200,
                FuelConsumption = 200
            };
            car.Drive(2000);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
