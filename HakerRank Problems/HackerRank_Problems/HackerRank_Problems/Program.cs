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
            Console.WriteLine(countingValleys(12, "UDDDUDUUDDUU"));
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
    }
}
