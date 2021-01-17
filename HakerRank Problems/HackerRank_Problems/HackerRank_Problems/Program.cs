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
            Console.WriteLine(jumpingOnClouds("0 1".Split(" ").Select(x => int.Parse(x)).ToArray()));
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

            return pairs;
        }

        public static int countingValleys(int steps, string path)
        {
            int count = 0;
            int diff = 0;

            for (int i = 0; i < steps; i++)
            {
                if (path[i] == 'U')
                {
                    diff++;
                    if (diff == 0)
                    {
                        count++;
                    }
                }
                else if (path[i] == 'D')
                {
                    diff--;
                }
            }

            return count;
        }

        static int jumpingOnClouds(int[] c)
        {
            int steps = 0;

            for (int i = 0; i < c.Length - 1; i++)
            {
                if (i + 2 < c.Length && c[i + 2] != 1)
                {
                    i++;
                }

                steps++;
            }

            return steps;
        }
    }
}
