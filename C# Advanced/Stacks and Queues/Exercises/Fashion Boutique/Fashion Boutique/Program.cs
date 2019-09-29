using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(x => int.Parse(x));
            int capacity = int.Parse(Console.ReadLine());
            int racks = 0;
            int sum = 0;
            var stack = new Stack<int>(numbers);

            while (sum < capacity)
            {
                if (stack.Count == 0)
                {
                    if (sum != 0)
                    {
                        racks++;
                        sum = 0;
                    }
                    break;
                }
                sum += stack.Peek();
                if (sum == capacity)
                {
                    sum = 0;
                    racks++;
                    stack.Pop();
                }
                else if (sum > capacity)
                {
                    sum = 0;
                    racks++;
                }
                else
                {
                    stack.Pop();
                    continue;
                }
            }
            Console.WriteLine(racks);
        }
    }
}
