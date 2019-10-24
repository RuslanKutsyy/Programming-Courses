using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }
            set { this.tires = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public void Drive(double distance)
        {
            double fuelQNeeded = distance/100 * this.fuelConsumption;
            if (fuelQNeeded > FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                FuelQuantity -= fuelQNeeded;
            }
        }

        public string WhoAmI()
        {
            string text = $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
            return text;
        }

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
    }

    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower
        {
            get { return this.horsePower; }
            set { this.horsePower = value; }
        }

        public double CubicCapacity
        {
            get { return this.cubicCapacity; }
            set { this.cubicCapacity = value; }
        }

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }

        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            string data = Console.ReadLine();
            List<Tire[]> tires = new List<Tire[]>();

            while (data != "No more tires")
            {
                var input = data.Split().ToArray();
                var tireSet = new Tire[4];
                string[] temp = new string[4];
                int year = 0;
                double pressure = 0;

                for (int i = 0; i < temp.Length; i++)
                {
                    for (int j = 0; j < input.Length; j += 2)
                    {
                        string tempStr = $"{input[j]} {input[j + 1]}";
                        temp[i] = tempStr;
                        i++;
                    }
                }

                for (int i = 0; i < tireSet.Length; i++)
                {
                    var values = temp[i].Split().ToArray();
                    year = int.Parse(values[0]);
                    pressure = double.Parse(values[1]);
                    tireSet[i] = new Tire(year, pressure);
                }
                tires.Add(tireSet);
                data = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            data = Console.ReadLine();
            while (data != "Engines done")
            {
                var parts = data.Split().ToArray();
                int horsePower = int.Parse(parts[0]);
                double cubicCapacity = double.Parse(parts[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
                data = Console.ReadLine();
            }

            string showSpecial = Console.ReadLine();

            List<Car> cars = new List<Car>();

            while (showSpecial != "Show special")
            {
                var parts = showSpecial.Split().ToArray();
                string make = parts[0];
                string model = parts[1];
                int year = int.Parse(parts[2]);
                double fuelQuantity = double.Parse(parts[3]);
                double fuelConsumption = double.Parse(parts[4]);
                int engineIndex = int.Parse(parts[5]);
                int tiresIndex = int.Parse(parts[6]);

                //тут проблемы з індексами енджина і тайрс
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);

                showSpecial = Console.ReadLine();
            }

            List<Car> filteredCarsByYearAndHorses = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330).ToList();
            var finalFilteredCars = new List<Car>();
            foreach (var car in filteredCarsByYearAndHorses)
            {
                bool result = FilterCars(car);
                if (result)
                {
                    finalFilteredCars.Add(car);
                }
            }

            for (int i = 0; i < finalFilteredCars.Count; i++)
            {
                finalFilteredCars[i].Drive(20);
            }

            foreach (var car in finalFilteredCars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }

        static public bool FilterCars(Car car)
        {
            double sum = 0;

            for (int i = 0; i < car.Tires.Length; i++)
            {
                sum += car.Tires[i].Pressure;
            }

            if (sum > 9 && sum < 10)
            {
                return true;
            }

            return false;
        }
    }
}