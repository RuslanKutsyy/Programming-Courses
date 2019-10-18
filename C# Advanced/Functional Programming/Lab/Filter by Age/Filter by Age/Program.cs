using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split().ToArray();
                string name = data[0];
                int age = int.Parse(data[1]);
                dict.Add(name, age);
            }

            string condition = Console.ReadLine();
            int conditionAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

        }
    }
}
