using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];

            matrix = AddNumsToMatrix(size);
            Matrix_Modification(matrix, size);

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]+ " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] AddNumsToMatrix(int size)
        {
            var matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int coll = 0; coll < size; coll++)
                {
                    matrix[row, coll] = input[coll];
                }
            }

            return matrix;
        }

        static int[,] Matrix_Modification(int[,] matrix, int size)
        {
            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                var input = cmd.Split();
                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                switch (command)
                {
                    case "Add":
                        {
                            if (!(row < 0 || row >= matrix.Length || col < 0 || col >= size))
                            {
                                matrix[row, col] += value;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coordinates");
                            }
                            break;
                        }
                    case "Subtract":
                        {
                            if (!(row < 0 || row >= matrix.Length || col < 0 || col >= size))
                            {
                                matrix[row, col] -= value;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coordinates");
                            }
                            break;
                        }
                    default:
                        break;
                }
                cmd = Console.ReadLine();
            }

            return matrix;
        }
    }
}
