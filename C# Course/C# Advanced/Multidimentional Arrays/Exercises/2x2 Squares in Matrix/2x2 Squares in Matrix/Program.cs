using System;
using System.Linq;

namespace _2x2_Squares_in_Matrix
{
    class Program
    {
        private static string[,] matrix;

        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            matrix = new string[rows, cols];
            AddNumsToMatrix(rows, cols);
            PrintCount(rows, cols);
        }

        static void AddNumsToMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static void PrintCount(int rows, int cols)
        {
            int count = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var element = matrix[row, col];
                    if (element == matrix[row, col + 1] && element == matrix[row + 1, col] && element == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
