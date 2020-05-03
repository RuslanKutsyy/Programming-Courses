using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> dict = new Dictionary<double, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], 1);
                }
                else
                {
                    dict[nums[i]]++;
                }
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }

        }
    }
}
