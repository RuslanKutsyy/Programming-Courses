using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace HackerRank_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(repeatedString("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 534802106762));
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

        static long repeatedString(string s, long n)
        {
            int aCount = s.Count(x => x == 'a');
            long countOfFullStr = n / s.Length;
            long additionalLetters = s.Substring(0, (int)(n % s.Length)).Count(x => x == 'a');

            return countOfFullStr * aCount + additionalLetters;

            //return s.Count(x => x == 'a') * (n / s.Length) + s.Substring(0, (int)n % s.Length).Count(x => x == 'a');


        }
    }
}
