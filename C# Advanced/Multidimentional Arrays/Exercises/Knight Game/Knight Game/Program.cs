using System;
using System.Collections.Generic;
using System.Linq;

namespace Knight_Game
{
    class Program
    {
        static string[,] matrix;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            matrix = new string[rows, rows];
            int kCount = 0;
            Dictionary<string, int> Dict = new Dictionary<string, int>();
            FillInMatrix(rows);

            while (true)
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < rows; col++)
                    {
                        if (matrix[row, col] == "K")
                        {
                            int connections = FindKnightWithMaxConnection(rows, row, col);
                            if (Dict.ContainsKey($"{row} {col}"))
                            {
                                Dict[$"{row} {col}"] = connections;
                            }
                            else
                            {
                                Dict.Add($"{row} {col}", connections);
                            }
                        }
                    }
                }

                //int maxConnections = int.MinValue;
                //string tempPosition = string.Empty;
                //foreach (var pair in Dict)
                //{
                //    if (pair.Value > maxConnections)
                //    {
                //        maxConnections = pair.Value;
                //        tempPosition = pair.Key;
                //    }
                //}

                var keyOfMax = Dict.FirstOrDefault(x => x.Value == Dict.Values.Max()).Key.Split().Select(int.Parse).ToArray();
                int rowofmatrix = keyOfMax[0];
                int colofmatrix = keyOfMax[0];
                matrix[rowofmatrix, colofmatrix] = "0";
                Dict.Remove($"{rowofmatrix} {colofmatrix}");

                if (Dict.Values.Sum() == 0)
                {
                    break;
                }

                kCount++;
            }

            Console.WriteLine(kCount);

        }

        static void FillInMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var data = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    matrix[row, col] = data[col].ToString();
                }
            }
        }

        static int FindKnightWithMaxConnection(int rows, int row, int col)
        {
            int knights = 0;
            int cols = rows;

            if (row + 1 < rows & col + 2 < cols)
            {
                if (matrix[row, col] == matrix[row + 1, col + 2])
                {
                    knights++;
                }
            }

            if (row + 2 < rows && col + 1 < cols)
            {
                if (matrix[row, col] == matrix[row + 2, col + 1])
                {
                    knights++;
                }
            }

            if (row + 2 < rows && col - 1 >= 0)
            {
                if (matrix[row, col] == matrix[row + 2, col - 1])
                {
                    knights++;
                }
            }

            if (row + 1 < rows && col - 2 >= 0)
            {
                if (matrix[row, col] == matrix[row + 1, col - 2])
                {
                    knights++;
                }
            }
            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (matrix[row, col] == matrix[row - 1, col - 2])
                {
                    knights++;
                }
            }

            if (row - 2 >= 0 && col - 1 >= 0)
            {
                if (matrix[row, col] == matrix[row - 2, col - 1])
                {
                    knights++;
                }
            }

            if (row - 2 >= 0 && col + 1 < cols)
            {
                if (matrix[row, col] == matrix[row - 2, col + 1])
                {
                    knights++;
                }
            }

            if (row - 1 >= 0 && col + 2 < cols)
            {
                if (matrix[row, col] == matrix[row - 1, col + 2])
                {
                    knights++;
                }
            }

            return knights;
        }
    }
}
