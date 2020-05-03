using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int minValue = int.MaxValue;
            Func<int, bool> FindMin = x => x < minValue;

            minValue = FindMinValue(numbers, minValue);
            Console.WriteLine(minValue);
        }

        public static int FindMinValue(int[] numbers, int minValue)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minValue)
                {
                    minValue = numbers[i];
                }
            }

            return minValue;
        }
    }
}
