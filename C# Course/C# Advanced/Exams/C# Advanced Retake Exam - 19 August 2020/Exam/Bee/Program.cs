using System;
using System.Collections.Generic;
using System.Text;

namespace Bee
{
    public class Program
    {
        static char[][] matrix;
        static int currentRow;
        static int currentColumn;
        static bool toEnd = true;
        static int pollinatedFlowersCount;
        static int neededPollinatedFlowersCount;
        static bool toWin;
        static bool toLose;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size][];
            toEnd = false;
            toWin = false;
            toLose = false;
            pollinatedFlowersCount = 0;
            neededPollinatedFlowersCount = 5;
            string stopCommand = "End";

            for (int row = 0; row < size; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                matrix[row] = input;

                for (int col = 0; col < input.Length; col++)
                {
                    if (input[col].Equals('B'))
                    {
                        currentRow = row;
                        currentColumn = col;
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

                if (move.Equals(stopCommand))
                {
                    toEnd = true;
                    break;
                }

                switch (move)
                {
                    case "up":
                        Move(-1, 0, "up");
                        break;
                    case "down":
                        Move(1, 0, "down");
                        break;
                    case "left":
                        Move(0, -1, "left");
                        break;
                    case "right":
                        Move(0, 1, "right");
                        break;
                    default:
                        break;
                }
            }

            StringBuilder sb = new StringBuilder();

            if (toLose)
            {
                sb.AppendLine("The bee got lost!");
            }

            string text = toWin ? $"Great job, the bee managed to pollinate {pollinatedFlowersCount} flowers!" : $"The bee couldn't pollinate the flowers, she needed {neededPollinatedFlowersCount - pollinatedFlowersCount} flowers more";
            sb.AppendLine(text);
            Console.WriteLine(sb.ToString().TrimEnd());
            PrintMatix();
        }

        public static void Move(int row, int col, string move)
        {
            int tempRow = currentRow + row;
            int tempCol = currentColumn + col;
            char flowerCell = 'f';
            char bonusCell = 'O';
            char position = 'B';
            char emptyCell = '.';

            if (tempRow < 0 || tempRow >= matrix.Length || tempCol < 0 || tempCol >= matrix.Length)
            {
                matrix[currentRow][currentColumn] = emptyCell;
                toEnd = true;
                toLose = true;
                return;
            }

            if (matrix[tempRow][tempCol].Equals(flowerCell))
            {
                pollinatedFlowersCount++;
                if (pollinatedFlowersCount == neededPollinatedFlowersCount)
                {
                    toWin = true;
                }
            }

            if (matrix[tempRow][tempCol].Equals(bonusCell))
            {
                matrix[tempRow][tempCol] = emptyCell;

                switch (move)
                {
                    case "up":
                        tempRow -= 1;
                        break;
                    case "down":
                        tempRow += 1;
                        break;
                    case "left":
                        tempCol -= 1;
                        break;
                    case "right":
                        tempCol += 1;
                        break;
                    default:
                        break;
                }

                if (tempRow < 0 || tempRow >= matrix.Length || tempCol < 0 || tempCol >= matrix.Length)
                {
                    matrix[currentRow][currentColumn] = emptyCell;
                    toEnd = true;
                    toLose = true;
                    return;
                }

                if (matrix[tempRow][tempCol].Equals(flowerCell))
                {
                    pollinatedFlowersCount++;
                    if (pollinatedFlowersCount == neededPollinatedFlowersCount)
                    {
                        toWin = true;
                    }
                }
            }

            matrix[currentRow][currentColumn] = emptyCell;
            matrix[tempRow][tempCol] = position;
            currentRow = tempRow;
            currentColumn = tempCol;
        }

        private static void PrintMatix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine($"{String.Join("", row)}");
            }
        }
    }
}
