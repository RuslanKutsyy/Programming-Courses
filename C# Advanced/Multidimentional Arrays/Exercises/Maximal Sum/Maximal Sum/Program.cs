using System;
using System.Linq;
using System.Numerics;

namespace Maximal_Sum
{
    class Program
    {
        public static int[,] matrix;

        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int rows = size[0];
            int cols = size[1];
            if (rows < 3 || cols < 3)
            {
                return;
            }
            matrix = new int[rows, cols];
            AddNumsToMatrix(rows, cols);
            FindAndPrintSum(rows, cols);

        }

        static void AddNumsToMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static void FindAndPrintSum(int rows, int cols)
        {
            int startRow = 0;
            int startCol = 0;
            int winRow = 0;
            int winCol = 0;
            int maxSum = int.MinValue;
            int sum = 0;

            while (startRow <= rows - 3)
            {
                while (startCol <= cols - 3)
                {
                    for (int row = startRow; row < startRow + 3; row++)
                    {
                        for (int col = startCol; col < startCol + 3; col++)
                        {
                            sum += matrix[row, col];
                        }
                    }
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        winRow = startRow;
                        winCol = startCol;
                    }
                    startCol++;
                    sum = 0;
                }
                startRow++;
                startCol = 0;
                sum = 0;
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = winRow; row <= winRow + 2; row++)
            {
                for (int col = winCol; col <= winCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
