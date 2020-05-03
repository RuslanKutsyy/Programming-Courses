using System;
using System.Linq;
using System.Collections.Generic;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < students; i++)
            {
                var data = Console.ReadLine().Split().ToArray();
                string name = data[0];
                double grade = double.Parse(data[1]);

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                    dict[name].Add(grade);
                }
                else
                {
                    dict[name].Add(grade);
                }
            }

            foreach (var pair in dict)
            {
                Console.Write($"{pair.Key} -> ");
                foreach (var item in pair.Value)
                {
                    Console.Write($"{item:F2} ");
                }
                Console.Write($"(avg: {pair.Value.Average():F2})");
                Console.WriteLine();
            }
        }
    }
}
