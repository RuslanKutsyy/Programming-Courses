using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            bool contains = false;

            for (int i = 0; i < size; i++)
            {
                var input = Console.ReadLine();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            char @char = char.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i,j] == @char)
                    {
                        contains = true;
                        Console.WriteLine($"({i}, {j})");
                        break;
                    }
                }
                if (contains)
                {
                    break;
                }
            }
            if (!contains)
            {
                Console.WriteLine($"{@char} does not occur in the matrix");
            }
        }
    }
}
