using System;
using System.Linq;
using System.Collections.Generic;

namespace Car_Salesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfEngines = int.Parse(Console.ReadLine());
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            string model;
            int power = 0;
            int displacement = 0;
            string efficiency = null;


            for (int i = 0; i < numOfEngines; i++)
            {
                var engineData = Console.ReadLine().Split().ToArray();
                model = engineData[0];
                power = int.Parse(engineData[1]);
                if (engineData.Length == 3)
                {
                    bool isInt = int.TryParse(engineData[2], out displacement);
                    if (!isInt)
                    {
                        efficiency = engineData[2];
                    }
                }
                else if (engineData.Length == 4)
                {
                    displacement = int.Parse(engineData[2]);
                    efficiency = engineData[3];
                }
                Engine engine = new Engine(model, power, displacement, efficiency);
                engines.Add(model, engine);
            }

            int numOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            string carModel;
            Engine carEngine = null;
            int weight = 0;
            string color = null;

            for (int i = 0; i < numOfCars; i++)
            {
                var carData = Console.ReadLine().Split().ToArray();

                carModel = carData[0];
                carEngine = engines[carData[1]];
                weight = 0;
                color = null;

                if (carData.Length == 3)
                {
                    bool isInt = int.TryParse(carData[2], out weight);
                    if (!isInt)
                    {
                        color = carData[2];
                    }
                }
                else if (carData.Length == 4)
                {
                    bool isInt = int.TryParse(carData[2], out weight);
                    if (isInt)
                    {
                        color = carData[3];
                    }
                    else
                    {
                        color = carData[2];
                        weight = int.Parse(carData[3]);
                    }
                }

                Car car = new Car(carModel, carEngine, weight, color);

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
