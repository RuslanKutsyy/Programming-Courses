using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static double[][] matrix;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            matrix = new double[rows][];

            FillInMatrix(rows);

            for (int row = 0; row < rows - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] *= 2;
                    }

                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }

                    for (int col = 0; col < matrix[row + 1].Length; col++)
                    {
                        matrix[row + 1][col] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (data[0] == "Add")
                {
                    AddNum(data, rows);
                }
                else if (data[0] == "Subtract")
                {
                    SubtractNum(data, rows);
                }

                command = Console.ReadLine();
            }

            PrintMatrix(rows);
        }

        static void FillInMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                matrix[row] = new double[nums.Length];

                for (int col = 0; col < nums.Length; col++)
                {
                    matrix[row][col] = nums[col];
                }
            }
        }

        static void AddNum(string[] data, int rows)
        {
            if (Validation(data, rows))
            {
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                double value = double.Parse(data[3]);

                matrix[row][col] += value;
            }
            else
            {
                return;
            }
        }

        static void SubtractNum(string[] data, int rows)
        {
            if (Validation(data, rows))
            {
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                double value = double.Parse(data[3]);

                matrix[row][col] -= value;
            }
            else
            {
                return;
            }
        }

        static bool Validation(string[] data, int rows)
        {
            int row = int.Parse(data[1]);
            int col = int.Parse(data[2]);

            if (row >= 0 && row < rows)
            {
                var tempArr = matrix[row];
                if (col < tempArr.Length && col >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        static void PrintMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join(" ", matrix[row]));
            }
        }

    }
}
