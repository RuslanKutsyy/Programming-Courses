using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(',', ' ', StringSplitOptions.RemoveEmptyEntries).Select(x=>int.Parse(x)).ToArray();
            int rows = size[0];
            int coll = size[1];
            var matrix = new int[rows, coll];
            int sum = 0;
            int jStart = 0;

            for (int i = 0; i < rows; i++)
            {
                var array = Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
                for (int j = 0; j < coll; j++)
                {
                    matrix[i, j] = array[j];
                }
            }
            for (int i = 0; i < rows; )
            {
                for (int j = jStart; j < coll; )
                {
                    if (i == rows)
                    {
                        break;
                    }
                    sum += matrix[i, j];
                    i++;
                }
                Console.WriteLine(sum);
                jStart++;
                i = 0;
                sum = 0;
                if (jStart == coll)
                {
                    break;
                }
            }
        }
    }
}
