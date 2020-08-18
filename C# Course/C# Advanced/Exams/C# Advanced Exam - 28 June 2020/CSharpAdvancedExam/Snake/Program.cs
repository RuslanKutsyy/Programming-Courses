using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Snake
{
    class Program
    {
        static char[][] matrix;
        static int currentRow;
        static int currentColumn;
        static bool toEnd = true;
        static List<string> burrowsCoordinates;
        static int foodCount;
        static int maxFoodCount;
        static bool toWin;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size][];
            burrowsCoordinates = new List<string>();
            toEnd = false;
            toWin = false;
            foodCount = 0;
            maxFoodCount = 10;

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < input.Length; col++)
                {
                    if (input[col].Equals('S'))
                    {
                        currentRow = row;
                        currentColumn = col;
                    }
                    if (input[col].Equals('B'))
                    {
                        burrowsCoordinates.Add($"{row} {col}");
                    }
                }
            }


            while (true)
            {
                if (toEnd)
                {
                    break;
                }

                string move = Console.ReadLine();

                switch (move)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                    default:
                        break;
                }
            }

            if (toEnd)
            {
                if (toWin)
                {
                    Console.WriteLine("You won! You fed the snake.");
                }
                else
                {
                    Console.WriteLine("Game over!");
                }
            }

            Console.WriteLine($"Food eaten: {foodCount}");

            PrintMatix();
        }

        private static void PrintMatix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine($"{String.Join("", row)}");
            }
        }

        public static void Move(int row, int col)
        {
            int tempRow = currentRow + row;
            int tempCol = currentColumn + col;

            if (tempRow < 0 || tempRow >= matrix.Length || tempCol < 0 || tempCol >= matrix.Length)
            {
                matrix[currentRow][currentColumn] = '.';
                toEnd = true;
                return;
            }

            if (matrix[tempRow][tempCol].Equals('B'))
            {
                matrix[tempRow][tempCol] = '.';
                burrowsCoordinates.Remove($"{tempRow} {tempCol}");
                var nextCoordinates = burrowsCoordinates[0].Split(" ").Select(int.Parse).ToArray();
                tempRow = nextCoordinates[0];
                tempCol = nextCoordinates[1];
            }

            if (matrix[tempRow][tempCol].Equals('*'))
            {
                foodCount++;
                if (foodCount == maxFoodCount)
                {
                    toEnd = true;
                    toWin = true;
                }
            }

            matrix[currentRow][currentColumn] = '.';
            matrix[tempRow][tempCol] = 'S';
            currentRow = tempRow;
            currentColumn = tempCol;
        }
    }
}
