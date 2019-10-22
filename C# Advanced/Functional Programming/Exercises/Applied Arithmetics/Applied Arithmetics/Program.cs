using System;
using System.Linq;
using System.Collections.Generic;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            Func<int, int> add = x => x += 1;
            Func<int, int> multiply = x => x *= 2;
            Func<int, int> subtract = x => x -= 1;
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        {
                            numbers = numbers.Select(add).ToList();
                            break;
                        }
                    case "multiply":
                        {
                            numbers = numbers.Select(multiply).ToList();
                            break;
                        }
                    case "subtract":
                        {
                            numbers = numbers.Select(subtract).ToList();
                            break;
                        }
                    case "print":
                        {
                            print(numbers);
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
