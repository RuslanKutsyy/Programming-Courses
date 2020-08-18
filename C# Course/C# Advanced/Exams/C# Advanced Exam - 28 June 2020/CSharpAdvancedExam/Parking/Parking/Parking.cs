using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public List<Car> Data;//test
        public string Type { get; set; }
        public int Capacity { get; set; }

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Data = new List<Car>();
        }

        public void Add(Car car)
        {
            if (this.Data.Count < this.Capacity)
            {
                this.Data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var car = this.Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (car == null)
            {
                return false;
            }

            this.Data.Remove(car);
            return true;
        }

        public Car GetLatestCar()
        {
            var latestCar = this.Data.OrderByDescending(x => x.Year).FirstOrDefault();

            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            var car = this.Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            return car;
        }

        public int Count
        {
            get
            {
                return this.Data.Count;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in this.Data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
