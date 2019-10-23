using System;

namespace CarManufacturer
{
    public class StartUp
    {
        class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
        }

        static void Main(string[] args)
        {
            Car car = new Car
            {
                Make = "VW",
                Model = "MK3",
                Year = 1992
            };

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
