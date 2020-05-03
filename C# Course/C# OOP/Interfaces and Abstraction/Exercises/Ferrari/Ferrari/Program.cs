using System;

namespace Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            string driverName = Console.ReadLine();
            ICar car = new Ferrari(driverName);

            Console.WriteLine(car.ToString());
        }
    }
}
