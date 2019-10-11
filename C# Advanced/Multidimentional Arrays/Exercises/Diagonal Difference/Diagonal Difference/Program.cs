using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            matrix = AddNumsToMatrix(size);
            int dif = Math.Abs(FirstDiagonalSum(matrix, size) - Second_Diagram_Sum(matrix, size));

            Console.WriteLine(dif);

        }

        static int[,] AddNumsToMatrix(int size)
        {
            var matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int coll = 0; coll < size; coll++)
                {
                    matrix[row, coll] = input[coll];
                }
            }
            return matrix;
        }

        static int FirstDiagonalSum(int[,] matrix, int size)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        static int Second_Diagram_Sum(int[,] matrix, int size)
        {
            int sum = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = size - 1; col >= 0; col--)
                {
                    sum += matrix[row, col];
                    row++;
                }
            }
            return sum;
        }
    }
}
