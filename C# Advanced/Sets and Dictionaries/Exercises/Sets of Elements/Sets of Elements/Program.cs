using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = data[0];
            int m = data[1];
            HashSet<int> nums1 = new HashSet<int>();
            HashSet<int> nums2 = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            for (int i = 1; i <= n + m; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (i <= n)
                {
                    nums1.Add(number);
                }
                else
                {
                    nums2.Add(number);
                }
            }

            foreach (var num in nums1)
            {
                if (nums2.Contains(num))
                {
                    result.Add(num);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
