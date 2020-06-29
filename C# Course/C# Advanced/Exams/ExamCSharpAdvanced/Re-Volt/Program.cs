using System;
using System.Linq;

namespace Re_Volt
{
    class Program
    {
        static int matrixSize;
        static int numOfCommands;
        static char[][] matrix;
        static int lastRow;
        static int lastCol;
        static int currentRow;
        static int currentCol;
        static string command;
        static bool toEnd;

        static void Main(string[] args)
        {
            matrixSize = int.Parse(Console.ReadLine());
            numOfCommands = int.Parse(Console.ReadLine());
            matrix = new char[matrixSize][];
            toEnd = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                matrix[row] = data;

                for (int col = 0; col < matrix.Length; col++)
                {
                    if (matrix[row][col] == 'f')
                    {
                        lastRow = currentRow = row;
                        lastCol = currentCol = col;
                        matrix[row][col] = '-';
                    }
                }
            }

            while (numOfCommands != 0)
            {
                command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(+1, 0);
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

                if (toEnd)
                {
                    break;
                }

                numOfCommands--;
            }


            if (!toEnd)
            {
                Console.WriteLine("Player lost!");
                matrix[currentRow][currentCol] = 'f';
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    Console.Write(matrix[row][col].ToString());
                }
                Console.Write(Environment.NewLine);
            }
        }

        private static bool isTrapped(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'T')
            {
                return true;
            }
            return false;
        }

        public static bool isFinished(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'F')
            {
                return true;
            }
            return false;
        }

        public static bool hasBonus(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] == 'B')
            {
                return true;
            }
            return false;
        }

        public static void Move (int row, int col)
        {
            lastRow = currentRow;
            lastCol = currentCol;
            currentRow = isOutOfBoundaries(currentRow + row);
            currentCol = isOutOfBoundaries(currentCol + col);


            if (isFinished(matrix, currentRow, currentCol))
            {
                Console.WriteLine("Player won!");
                matrix[currentRow][currentCol] = 'f';
                toEnd = true;
                return;
            }
            else if (hasBonus(matrix, currentRow, currentCol))
            {
                lastRow = currentRow;
                lastCol = currentCol;

                if (command == "up")
                {
                    currentRow  = isOutOfBoundaries(currentRow - 1);
                }
                else if (command == "down")
                {
                    currentRow = isOutOfBoundaries(currentRow + 1);
                }
                else if (command == "left")
                {
                    currentCol = isOutOfBoundaries(currentCol - 1);
                }
                else if (command == "right")
                {
                    currentCol = isOutOfBoundaries(currentCol + 1);
                }

                if (isFinished(matrix, currentRow, currentCol))
                {
                    Console.WriteLine("Player won!");
                    matrix[currentRow][currentCol] = 'f';
                    toEnd = true;
                    return;
                }
            }
            else if (isTrapped(matrix, currentRow, currentCol))
            {
                currentRow = lastRow;
                currentCol = lastCol;
            }
        }

        private static int isOutOfBoundaries(int data)
        {
            if (data < 0)
            {
                data = matrixSize - 1;
            }
            else if (data == matrixSize)
            {
                data = 0;
            }

            return data;
        }
    }
}
