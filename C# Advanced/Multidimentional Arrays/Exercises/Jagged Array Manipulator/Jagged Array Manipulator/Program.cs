using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static int[][] matrix;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            matrix = new int[rows][];

            FillInMatrix(rows);
            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command.StartsWith("Add"))
                {
                    AddNum(command, rows);
                }
                else
                {
                    SubtractNum(command, rows);
                }

                command = Console.ReadLine();
            }
        }

        static void FillInMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new int[nums.Length];

                for (int col = 0; col < nums.Length; col++)
                {
                    matrix[row][col] = nums[col];
                }
            }
        }

        static void AddNum(string command, int rows)
        {
            if (Validation(command, rows))
            {
                
            }
            else
            {
                return;
            }
        }

        static void SubtractNum(string command, int rows)
        {

        }

        static bool Validation(string command, int rows)
        {
            var data = command.Split().ToArray();

            int row = int.Parse(data[1]);
            int col = int.Parse(data[2]);

            if (row >=0 && row < rows)
            {
                var tempArr = matrix[row];
                if (col < tempArr.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
