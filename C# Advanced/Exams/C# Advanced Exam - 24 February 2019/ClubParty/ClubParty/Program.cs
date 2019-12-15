using System;
using System.Collections.Generic;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallMaxCapacity = int.Parse(Console.ReadLine());
            Stack<string> reservationData = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            Dictionary<string, int> reservations = new Dictionary<string, int>();

            while (true)
            {
                if (reservationData.Count == 0)
                {
                    break;
                }

                var sign = reservationData.Pop();



            }
            
        }
    }
}
