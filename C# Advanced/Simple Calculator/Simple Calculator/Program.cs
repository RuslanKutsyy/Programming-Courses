using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>();
            int sum = 0;
            int count = 1;

            foreach (var item in input.Reverse())
            {
                stack.Push(item);
            }

            while (true)
            {
                if (stack.Count==0)
                {
                    break;
                }

                int num1 = sum;
                string @operator = string.Empty;

                if (count == 1)
                {
                    @operator = "+";
                    count = 0;
                }
                else
                {
                    @operator = stack.Pop();
                }

                int num2 = int.Parse(stack.Pop());

                switch (@operator)
                {
                    case "+":
                        {
                            sum = num1 + num2;
                            break;
                        }
                    case "-":
                        {
                            sum = num1 - num2;
                            break;
                        }

                    default:
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
