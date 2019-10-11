using System;
using System.Linq;

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
            int sum = 0;
            int maxSum = int.MinValue;
            int rowCount = 0;
            int colCount = 0;
            int[,] winMatrix = new int[3, 3];

            for (int mainRow = 0; mainRow < rows; )
            {
                for (int row = 0; row < rows; row++)
                {

                }
            }
        }
    }
}
