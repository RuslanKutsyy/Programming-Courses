using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static char[,] matrix;

        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            matrix = new char[rows, cols];
            string snake = Console.ReadLine();

            SnakeRun(rows, cols, snake);
            PrintMatrix(rows, cols);

        }

        static void SnakeRun(int rows, int cols, string snake)
        {
            List<char> tempSnake = snake.ToList();
            int charCounter = 0;

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = tempSnake[charCounter];
                        charCounter++;
                        if (charCounter == tempSnake.Count)
                        {
                            charCounter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = tempSnake[charCounter];
                        charCounter++;
                        if (charCounter == tempSnake.Count)
                        {
                            charCounter = 0;
                        }
                    }
                }
            }
        }

        static void PrintMatrix(int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
