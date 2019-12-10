using System;
using System.Linq;
using System.Collections.Generic;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int galaxySize = int.Parse(Console.ReadLine());
            char[,] galaxyMatrix = new char[galaxySize, galaxySize];
            int currrentRow = 0;
            int currentCol = 0;
            List<string> blackholes = new List<string>();
            bool @void = false;
            int starPower = 0;

            for (int row = 0; row < galaxySize; row++)
            {
                char[] data = Console.ReadLine().ToCharArray();
                for (int col = 0; col < galaxySize; col++)
                {
                    galaxyMatrix[row, col] = data[col];
                    if (data[col] == 'S')
                    {
                        currrentRow = row;
                        currentCol = col;
                    }
                    if (data[col] == 'O')
                    {
                        blackholes.Add($"{row}{col}");
                    }
                }
            }

            while (true)
            {
                if (@void || starPower >= 50)
                {
                    break;
                }

                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        {
                            if (currrentRow - 1 >= 0)
                            {
                                if (galaxyMatrix[currrentRow - 1, currentCol] == 'O')
                                {
                                    galaxyMatrix[currrentRow , currentCol] = '-';
                                    galaxyMatrix[currrentRow - 1, currentCol] = '-';
                                    blackholes.Remove($"{currrentRow - 1}{currentCol}");
                                    var blackhole = blackholes[0].ToCharArray();
                                    currrentRow = (int)char.GetNumericValue(blackhole[0]);
                                    currentCol = (int)char.GetNumericValue(blackhole[1]);
                                    galaxyMatrix[currrentRow, currentCol] = 'S';
                                }
                                else if (galaxyMatrix[currrentRow - 1, currentCol] == '-')
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    galaxyMatrix[currrentRow - 1, currentCol] = 'S';
                                    currrentRow -= 1;
                                }
                                else
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    starPower += (int)char.GetNumericValue(galaxyMatrix[currrentRow - 1, currentCol]);
                                    galaxyMatrix[currrentRow - 1, currentCol] = 'S';
                                    currrentRow = currrentRow - 1;
                                }
                            }
                            else
                            {
                                galaxyMatrix[currrentRow, currentCol] = '-';
                                @void = true;
                            }
                            break;
                        }
                    case "down":
                        {
                            if (currrentRow + 1 < galaxySize)
                            {
                                if (galaxyMatrix[currrentRow + 1, currentCol] == 'O')
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    galaxyMatrix[currrentRow + 1, currentCol] = '-';
                                    blackholes.Remove($"{currrentRow + 1}{currentCol}");
                                    var blackhole = blackholes[0].ToCharArray();
                                    currrentRow = (int)char.GetNumericValue(blackhole[0]);
                                    currentCol = (int)char.GetNumericValue(blackhole[1]);
                                    galaxyMatrix[currrentRow, currentCol] = 'S';
                                }
                                else if (galaxyMatrix[currrentRow + 1, currentCol] == '-')
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    galaxyMatrix[currrentRow + 1, currentCol] = 'S';
                                    currrentRow += 1;
                                }
                                else
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    starPower += (int)char.GetNumericValue(galaxyMatrix[currrentRow + 1, currentCol]);
                                    galaxyMatrix[currrentRow + 1, currentCol] = 'S';
                                    currrentRow = currrentRow + 1;
                                }
                            }
                            else
                            {
                                galaxyMatrix[currrentRow, currentCol] = '-';
                                @void = true;
                            }
                            break;
                        }
                    case "left":
                        {
                            if (currentCol - 1 >= 0)
                            {
                                if (galaxyMatrix[currrentRow, currentCol - 1] == 'O')
                                {
                                    galaxyMatrix[currrentRow, currentCol - 1] = '-';
                                    galaxyMatrix[currrentRow, currentCol - 1] = '-';
                                    blackholes.Remove($"{currrentRow}{currentCol - 1}");
                                    var blackhole = blackholes[0].ToCharArray();
                                    currrentRow = (int)char.GetNumericValue(blackhole[0]);
                                    currentCol = (int)char.GetNumericValue(blackhole[1]);
                                    galaxyMatrix[currrentRow, currentCol] = 'S';
                                }
                                else if (galaxyMatrix[currrentRow, currentCol - 1] == '-')
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    galaxyMatrix[currrentRow, currentCol - 1] = 'S';
                                    currentCol -= 1;
                                }
                                else
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    starPower += (int)char.GetNumericValue(galaxyMatrix[currrentRow, currentCol - 1]);
                                    galaxyMatrix[currrentRow, currentCol - 1] = 'S';
                                    currentCol = currentCol - 1;
                                }
                            }
                            else
                            {
                                galaxyMatrix[currrentRow, currentCol] = '-';
                                @void = true;
                            }
                            break;
                        }
                    case "right":
                        {
                            if (currentCol + 1 < galaxySize)
                            {
                                if (galaxyMatrix[currrentRow, currentCol + 1] == 'O')
                                {
                                    galaxyMatrix[currrentRow, currentCol + 1] = '-';
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    blackholes.Remove($"{currrentRow}{currentCol + 1}");
                                    var blackhole = blackholes[0].ToCharArray();
                                    currrentRow = (int)char.GetNumericValue(blackhole[0]);
                                    currentCol = (int)char.GetNumericValue(blackhole[1]);
                                    galaxyMatrix[currrentRow, currentCol] = 'S';
                                }
                                else if (galaxyMatrix[currrentRow, currentCol + 1] == '-')
                                {
                                    galaxyMatrix[currrentRow, currentCol + 1] = 'S';
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    currentCol += 1;
                                }
                                else
                                {
                                    galaxyMatrix[currrentRow, currentCol] = '-';
                                    starPower += (int)char.GetNumericValue(galaxyMatrix[currrentRow, currentCol + 1]);
                                    galaxyMatrix[currrentRow, currentCol + 1] = 'S';
                                    currentCol = currentCol + 1;
                                }
                            }
                            else
                            {
                                galaxyMatrix[currrentRow, currentCol] = '-';
                                @void = true;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            if (starPower >= 50 && !@void)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }

            Console.WriteLine($"Star power collected: {starPower}");

            for (int row = 0; row < galaxySize; row++)
            {
                for (int col = 0; col < galaxySize; col++)
                {
                    Console.Write(galaxyMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
