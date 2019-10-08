using System;
using System.Linq;

namespace Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(',', ' ').Select(int.Parse).ToArray();
            var matrix = new int[size[0], size[1]];
            int sum = 0;
            int maxSum = int.MinValue;

            for (int i = 0; i < size[0]; i++)
            {
                var input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    sum += matrix[i, j];
                }   
            }
        }
    }
}
