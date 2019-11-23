using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var webSites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var smartphone = new Smartphone();

            foreach (var number in phoneNumbers)
            {
                smartphone.Call(number);
            }

            foreach (var website in webSites)
            {
                smartphone.Browse(website);
            }
        }
    }
}
