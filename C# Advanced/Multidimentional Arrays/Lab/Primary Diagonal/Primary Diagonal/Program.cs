using System;
using System.Linq;

namespace Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new int[size, size];
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                var array = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = array[j];
                }
            }

            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }
            Console.WriteLine(sum);
        }
    }
}
