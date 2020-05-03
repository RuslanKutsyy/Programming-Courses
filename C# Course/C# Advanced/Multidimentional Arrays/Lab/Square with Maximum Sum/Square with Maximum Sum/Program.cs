using System;
using System.Linq;

namespace Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            int rows = size[0];
            int colls = size[1];
            var matrix = new int[rows, colls];

            matrix = addToMatrix(rows, colls, input);
            printResults(rows, colls, matrix);

        }

        static int[,] addToMatrix(int rows, int colls, string input)
        {
            var matrix = new int[rows, colls];
            var data = input.Split(", ").Select(int.Parse).ToArray();

            for (int row = 0; row < rows; row++)
            {
                for (int coll = 0; coll < colls; coll++)
                {
                    matrix[row, coll] = data[coll];
                }
                if (row != rows - 1)
                {
                    data = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                }
            }
            return matrix;
        }

        static void printResults(int rows, int colls, int[,] matrix)
        {
            int maxSum = int.MinValue;
            string win1 = string.Empty;
            string win2 = string.Empty;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int coll = 0; coll < colls - 1; coll++)
                {
                    int tempSum = matrix[row, coll] + matrix[row, coll + 1] + matrix[row + 1, coll] + matrix[row + 1, coll + 1];
                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        win1 = $"{matrix[row, coll]} {matrix[row, coll + 1]}";
                        win2 = $"{matrix[row + 1, coll]} {matrix[row + 1, coll + 1]}";
                    }
                }
            }
            Console.WriteLine(win1);
            Console.WriteLine(win2);
            Console.WriteLine(maxSum);
        }
    }
}
