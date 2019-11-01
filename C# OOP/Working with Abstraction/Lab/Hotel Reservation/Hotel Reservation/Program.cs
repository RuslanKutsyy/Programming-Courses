using System;
using System.Linq;

namespace Hotel_Reservation
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservationInfo = Console.ReadLine().Split().ToArray();
            
            Console.WriteLine($"{PriceCalculator.GetTotalPrice(reservationInfo):F2}");
        }
    }
}
