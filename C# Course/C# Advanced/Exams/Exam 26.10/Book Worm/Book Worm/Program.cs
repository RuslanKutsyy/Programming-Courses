using System;
using System.Linq;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            int size = int.Parse(Console.ReadLine());
            var matrix = new char[size,size];
            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < size; i++)
            {
                var rowText = Console.ReadLine().ToCharArray();
                for (int j = 0; j < rowText.Length; j++)
                {
                    if (rowText[j] == 'P')
                    {
                        startRow = i;
                        startCol = j;
                        matrix[i, j] = '-';
                    }
                    else
                    {
                        matrix[i, j] = rowText[j];
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "up":
                        {
                            if (startRow - 1 >= 0)
                            {
                                if (matrix[startRow - 1, startCol] != '-')
                                {
                                    initial += matrix[startRow - 1, startCol];
                                    matrix[startRow, startCol] = '-';
                                    startRow = startRow - 1;
                                }
                                else
                                {
                                    startRow = startRow - 1;
                                }
                            }
                            else
                            {
                                //matrix[startRow, startCol] = '-';
                                if (initial.Length!=0)
                                {
                                    initial = initial.Remove(initial.Length - 1);
                                }
                            }
                            matrix[startRow, startCol] = 'P';
                            break;
                        }
                    case "down":
                        {
                            if (startRow + 1 < size)
                            {
                                if (matrix[startRow + 1, startCol] != '-')
                                {
                                    initial += matrix[startRow + 1, startCol];
                                    matrix[startRow, startCol] = '-';
                                    startRow = startRow + 1;
                                }
                                else
                                {
                                    matrix[startRow, startCol] = '-';
                                    startRow = startRow + 1;
                                }
                            }
                            else
                            {
                                if (initial.Length != 0)
                                {
                                    initial = initial.Remove(initial.Length - 1);
                                }
                            }
                            matrix[startRow, startCol] = 'P';
                            break;
                        }
                    case "left":
                        {
                            if (startCol - 1 >= 0)
                            {
                                if (matrix[startRow, startCol - 1] != '-')
                                {
                                    initial += matrix[startRow, startCol - 1];
                                    matrix[startRow, startCol] = '-';
                                    startCol = startCol - 1;
                                }
                                else
                                {
                                    matrix[startRow, startCol] = '-';
                                    startCol = startCol - 1;
                                }
                            }
                            else
                            {
                                if (initial.Length != 0)
                                {
                                    initial = initial.Remove(initial.Length - 1);
                                }
                            }
                            matrix[startRow, startCol] = 'P';
                            break;
                        }
                    case "right":
                        {
                            if (startCol + 1 < size)
                            {
                                if (matrix[startRow, startCol + 1] != '-')
                                {
                                    initial += matrix[startRow, startCol + 1];
                                    matrix[startRow, startCol] = '-';
                                    startCol = startCol + 1;
                                }
                                else
                                {
                                    startCol = startCol + 1;

                                }
                            }
                            else
                            {
                                //matrix[startRow, startCol] = '-';
                                if (initial.Length != 0)
                                {
                                    initial = initial.Remove(initial.Length - 1);
                                }
                            }
                            matrix[startRow, startCol] = 'P';
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(initial);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
