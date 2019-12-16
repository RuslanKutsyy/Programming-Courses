using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallMaxCapacity = int.Parse(Console.ReadLine());
            Stack<string> reservationData = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Dictionary<string, List<int>> sortedData = new Dictionary<string, List<int>>();

            while (true)
            {
                if (reservationData.Count == 0)
                {
                    break;
                }

                bool isInt = int.TryParse(reservationData.Peek(), out int num);

                if (isInt && sortedData.Count == 0 )
                {
                    reservationData.Pop();
                    continue;
                }
                else if (isInt && sortedData.Count > 0)
                {
                    foreach (var item in sortedData)
                    {
                        int sum = item.Value.Sum();
                        if (sum < hallMaxCapacity && sum + num <= hallMaxCapacity)
                        {
                            item.Value.Add(num);
                            break;
                        }
                    }
                    reservationData.Pop();
                }
                else if (!isInt)
                {
                    sortedData.Add(reservationData.Pop(), new List<int>());
                }
            }
            ;
        }
    }
}
