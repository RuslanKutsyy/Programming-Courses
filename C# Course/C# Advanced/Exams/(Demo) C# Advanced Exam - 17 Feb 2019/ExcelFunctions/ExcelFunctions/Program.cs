using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelFunctions
{
    class Program
    {
        public static string[][] matrix;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            matrix = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                var data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                matrix[i] = data;
            }

            var cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = cmd[0];

            if (command == "hide")
            {
                string header = cmd[1];
                int indexOfHeader = Array.IndexOf(matrix[0], header);

                for (int row = 0; row < rows; row++)
                {
                    List<string> tempRow = matrix[row].ToList();
                    tempRow.RemoveAt(indexOfHeader);
                    matrix[row] = tempRow.ToArray();
                }

                for (int row = 0; row < rows; row++)
                {
                    Console.WriteLine(string.Join(" | ", matrix[row]));
                }
            }
            else if (command == "sort")
            {
                string header = cmd[1];
                int indexOfTarget = Array.IndexOf(matrix[0], header);
                string[] headerRow = matrix[0];

                Console.WriteLine(string.Join(" | ", matrix[0]));

                matrix = matrix.OrderBy(x => x[indexOfTarget]).ToArray();

                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row] != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }
            else if (command == "filter")
            {
                string filter = cmd[1];
                string filterValue = cmd[2];

                int indexOFTarget = Array.IndexOf(matrix[0], filter);

                Console.WriteLine(string.Join(" | ", matrix[0]));

                for (int row = 1; row < rows; row++)
                {
                    if (matrix[row][indexOFTarget] == filterValue)
                    {
                        Console.WriteLine(string.Join(" | ", matrix[row]));
                    }
                }
            }


        }
    }
}
