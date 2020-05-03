using System;
using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(Environment.CurrentDirectory + "\\Input.txt"))
            {
                int counter = 1;
                string line = reader.ReadLine();

                using (var writer = new StreamWriter(Environment.CurrentDirectory + "\\Output.txt"))
                {
                    while (line != null)
                    {
                        writer.WriteLine($"{counter}. {line}");
                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
