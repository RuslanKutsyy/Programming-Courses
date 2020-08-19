using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lilies = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
            var roses = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
            var sumList = new List<int>();
            int wreathsCount = 0;
            int neededSum = 15;

            while (true)
            {
                if (roses.Count == 0 || lilies.Count == 0)
                {
                    break;
                }

                var roseElement = roses.Peek();
                var lilyElement = lilies.Peek();
                var flowersSum = roseElement + lilyElement;

                if (flowersSum > neededSum)
                {
                    var stackAsList = lilies.ToList();
                    stackAsList[0] -= 2;
                    stackAsList.Reverse();

                    lilies = new Stack<int>(stackAsList);
                }
                else if (flowersSum == neededSum)
                {
                    wreathsCount += 1;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else
                {
                    sumList.Add(flowersSum);
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            if (sumList.Count > 0)
            {
                int additionalWreathes = sumList.Sum() / neededSum;
                wreathsCount += additionalWreathes;
            }

            if (wreathsCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCount} wreaths more!");
            }
        }
    }
}
