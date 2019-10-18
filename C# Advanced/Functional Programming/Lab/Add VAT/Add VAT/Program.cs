using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, double> doublesPlusVAT = x => double.Parse(x) * 1.2;

            var prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(doublesPlusVAT).ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
