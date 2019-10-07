using System;
using System.Linq;

namespace Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(',', ' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int rows = int.Parse(size[0]);
            int coll = int.Parse(size[1]);
            var matrix = new int[rows, coll];
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                var array = Console.ReadLine().Split(',', ' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                sum += array.Sum();
                for (int j = 0; j < coll; j++)
                {
                    matrix[i, j] = array[j];
                }
            }
            Console.WriteLine(rows);
            Console.WriteLine(coll);
            Console.WriteLine(sum);
        }
    }
}
