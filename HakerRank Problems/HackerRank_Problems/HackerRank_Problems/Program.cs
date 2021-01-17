using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace HackerRank_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sockMerchant(9, "10 20 20 10 10 30 50 10 20".Split(" ").Select(x => int.Parse(x)).ToArray()));
        }


        static int sockMerchant(int n, int[] ar)
        {
            int pairs = 0;

            var colors = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                if (!colors.Contains(ar[i]))
                {
                    colors.Add(ar[i]);
                }
                else
                {
                    pairs++;
                    colors.Remove(ar[i]);
                }
            }

            //pairs /= 2;

            return pairs;
        }
    }
}
