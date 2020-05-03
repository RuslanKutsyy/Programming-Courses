using System;
using System.Collections.Generic;
using System.Linq;

namespace SeashellTreasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] matrix = new string[rows][];
            List<string> collected = new List<string>();
            int stolen = 0;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            string cmd = Console.ReadLine();

            while (cmd!= "Sunset")
            {
                var commands = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);

                if (commands[0] == "Collect")
                {
                    if (row < rows && rows >= 0 && col < matrix[row].Length && col >= 0 && matrix[row][col] != "-")
                    {
                        collected.Add(matrix[row][col]);
                        matrix[row][col] = "-";
                    }
                }
                else if (commands[0] == "Steal")
                {
                    string direction = commands[3];

                    if (row < rows && row >= 0 && col < matrix[row].Length && col >= 0 && matrix[row][col] != "-")
                    {
                        stolen++;
                        matrix[row][col] = "-";

                        switch (direction)
                        {
                            case "up":
                                {
                                    if (row - 3 >= 0)
                                    {
                                        for (int i = row - 1; i >= row - 3; i--)
                                        {
                                            if (matrix[i][col] != "-")
                                            {
                                                stolen++;
                                                matrix[i][col] = "-";
                                            }
                                        }
                                    }
                                    break;
                                }
                            case "down":
                                {
                                    if (row + 3 < rows)
                                    {
                                        for (int i = row + 1; i <= row + 3; i++)
                                        {
                                            if (matrix[i][col] != "-")
                                            {
                                                stolen++;
                                                matrix[i][col] = "-";
                                            }
                                        }
                                    }
                                    break;
                                }
                            case "left":
                                {
                                    if (col - 3 >= 0)
                                    {
                                        for (int i = col - 1; i >= col - 3; i--)
                                        {
                                            if (matrix[i][col] != "-")
                                            {
                                                stolen++;
                                                matrix[i][col] = "-";
                                            }
                                        }
                                    }
                                    break;
                                }
                            case "right":
                                {
                                    if (col + 3 < matrix[row].Length)
                                    {
                                        for (int i = col + 1; i <= col + 3; i++)
                                        {
                                            if (matrix[i][col] != "-")
                                            {
                                                stolen++;
                                                matrix[i][col] = "-";
                                            }
                                        }
                                    }
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                cmd = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine($"{string.Join(" ", row)} ");
            }

            if (collected.Count != 0)
            {
                Console.Write($"Collected seashells: {collected.Count} -> ");
                Console.Write(string.Join(", ", collected));
                Console.WriteLine();
                Console.WriteLine($"Stolen seashells: {stolen}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collected.Count}");
                Console.WriteLine($"Stolen seashells: {stolen}");
            }
        }
    }
}
