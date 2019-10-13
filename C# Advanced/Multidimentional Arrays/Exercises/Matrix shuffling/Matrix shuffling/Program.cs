using System;
using System.Linq;

namespace Matrix_shuffling
{
    class Program
    {
        static string[,] matrix;

        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            matrix = new string[rows,cols];

            AddNumsToMatrix(rows, cols);
            string command = Console.ReadLine();

            while (command != "END")
            {
                var cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (CommandValidation(cmd, rows, cols))
                {
                    SwapValues(command, rows, cols);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }

        }

        static void AddNumsToMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }
        }

        static bool CommandValidation(string[] command, int rows, int cols)
        {
            if (command.Length == 5)
            {
                string cmd = command[0];
                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                if (row1 < rows && row2 < rows && col1 < cols && col2 < cols)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        static void SwapValues(string command, int rows, int cols)
        {
            var cmd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int row1 = int.Parse(cmd[1]);
            int col1 = int.Parse(cmd[2]);
            int row2 = int.Parse(cmd[3]);
            int col2 = int.Parse(cmd[4]);

            string temp = matrix[row1, col1];
            matrix[row1, col1] = matrix[row2, col2];
            matrix[row2, col2] = temp;

            PrintMatrix(rows, cols);
        }

        static void PrintMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
