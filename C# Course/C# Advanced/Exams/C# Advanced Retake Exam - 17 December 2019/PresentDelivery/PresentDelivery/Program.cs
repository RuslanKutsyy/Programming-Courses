using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        public static string[,] matrix;
        public static int presentCount;
        public static int positionRow;
        public static int positionCol;
        static void Main(string[] args)
        {
            presentCount = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int niceKindsCount = 0;
            matrix = new string[size, size];

            for (int row = 0; row < size; row++)
            {
                var data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = data[col];
                    if (matrix[row, col] == "S")
                    {
                        positionRow = row;
                        positionCol = col;
                    }
                    if (matrix[row, col] == "V")
                    {
                        niceKindsCount++;
                    }
                }
            }


            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "Christmas morning" || presentCount == 0)
                {
                    break;
                }

                switch (cmd)
                {
                    case "up":
                        {
                            if (positionRow - 1 >= 0)
                            {
                                matrix[positionRow, positionCol] = "-";
                                if (matrix[positionRow - 1, positionCol] == "X")
                                {
                                    matrix[positionRow - 1, positionCol] = "S";
                                    positionRow -= 1;
                                }
                                if (matrix[positionRow - 1, positionCol] == "V")
                                {
                                    matrix[positionRow - 1, positionCol] = "S";
                                    positionRow -= 1;
                                    presentCount--;
                                    niceKindsCount--;
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                if (matrix[positionRow - 1, positionCol] == "C")
                                {
                                    matrix[positionRow - 1, positionCol] = "S";
                                    positionRow -= 1;
                                    GoAround(positionRow, positionCol, size);
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    matrix[positionRow - 1, positionCol] = "S";
                                    positionRow -= 1;
                                }
                            }
                            break;
                        }
                    case "down":
                        {
                            if (positionRow + 1 < size)
                            {
                                matrix[positionRow, positionCol] = "-";
                                if (matrix[positionRow + 1, positionCol] == "X")
                                {
                                    matrix[positionRow + 1, positionCol] = "S";
                                    positionRow += 1;
                                }
                                if (matrix[positionRow + 1, positionCol] == "V")
                                {
                                    matrix[positionRow + 1, positionCol] = "S";
                                    positionRow += 1;
                                    presentCount--;
                                    niceKindsCount--;
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                if (matrix[positionRow + 1, positionCol] == "C")
                                {
                                    matrix[positionRow + 1, positionCol] = "S";
                                    positionRow += 1;
                                    GoAround(positionRow, positionCol, size);
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    matrix[positionRow + 1, positionCol] = "S";
                                    positionRow += 1;
                                }
                            }
                            break;
                        }
                    case "left":
                        {
                            if (positionCol - 1 >= 0)
                            {
                                matrix[positionRow, positionCol] = "-";
                                if (matrix[positionRow, positionCol - 1] == "X")
                                {
                                    matrix[positionRow, positionCol - 1] = "S";
                                    positionCol -= 1;
                                }
                                if (matrix[positionRow, positionCol - 1] == "V")
                                {
                                    matrix[positionRow, positionCol - 1] = "S";
                                    positionCol -= 1;
                                    presentCount--;
                                    niceKindsCount--;
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                if (matrix[positionRow, positionCol - 1] == "C")
                                {
                                    matrix[positionRow, positionCol - 1] = "S";
                                    positionCol -= 1;
                                    GoAround(positionRow, positionCol, size);
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    matrix[positionRow, positionCol - 1] = "S";
                                    positionCol -= 1;
                                }
                            }
                            break;
                        }
                    case "right":
                        {
                            if (positionCol + 1 < size)
                            {
                                matrix[positionRow, positionCol] = "-";
                                if (matrix[positionRow, positionCol + 1] == "X")
                                {
                                    matrix[positionRow, positionCol + 1] = "S";
                                    positionCol += 1;
                                }
                                if (matrix[positionRow, positionCol + 1] == "V")
                                {
                                    matrix[positionRow, positionCol + 1] = "S";
                                    positionCol += 1;
                                    presentCount--;
                                    niceKindsCount--;
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                if (matrix[positionRow, positionCol + 1] == "C")
                                {
                                    matrix[positionRow, positionCol + 1] = "S";
                                    positionCol += 1;
                                    GoAround(positionRow, positionCol, size);
                                    if (presentCount == 0)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    matrix[positionRow, positionCol + 1] = "S";
                                    positionCol += 1;
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            if (presentCount == 0)
            {
                Console.WriteLine("Santa ran out of presents.");
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            if (niceKindsCount == 0)
            {
                Console.WriteLine("Good job, Santa! {count nice kids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKindsCount} nice kid/s.");
            }

        }

        public static void GoAround(int positionRow, int positionCol, int size)
        {
            if (positionRow - 1 >= 0 && matrix[positionRow - 1, positionCol] != "-") //up
            {
                matrix[positionRow - 1, positionCol] = "-";
                presentCount--;
                if (presentCount == 0)
                {
                    return;
                }
            }
            if (positionRow + 1 < size && matrix[positionRow - 1, positionCol] != "-") //down
            {
                matrix[positionRow + 1, positionCol] = "-";
                presentCount--;
                if (presentCount == 0)
                {
                    return;
                }
            }
            if (positionCol - 1 >= 0 && matrix[positionRow, positionCol - 1] != "-") // left
            {
                matrix[positionRow, positionCol - 1] = "-";
                presentCount--;
                if (presentCount == 0)
                {
                    return;
                }
            }
            if (positionCol + 1 < size && matrix[positionRow, positionCol + 1] != "-") // left
            {
                matrix[positionRow, positionCol + 1] = "-";
                presentCount--;
                if (presentCount == 0)
                {
                    return;
                }
            }
        }

        
    }
}
