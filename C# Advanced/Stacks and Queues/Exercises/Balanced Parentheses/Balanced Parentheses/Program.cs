using System;
using System.Collections.Generic;

namespace Balanced_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var firstQueue = new Queue<char>();
            var secondQueue = new Queue<char>();
            bool balanced = true;

            if (input.Length % 2 == 0)
            {
                for (int i = 1; i <= input.Length / 2; i++)
                {
                    firstQueue.Enqueue(input[i - 1]);
                }

                for (int i = input.Length; i >= input.Length / 2 + 1; i--)
                {
                    secondQueue.Enqueue(input[i - 1]);
                }

                while (true)
                {
                    if (!balanced)
                    {
                        Console.WriteLine("NO");
                        break;
                    }
                    else if (firstQueue.Count == 0)
                    {
                        break;
                    }

                    char firstString = firstQueue.Peek();

                    switch (firstString)
                    {
                        case '{':
                            {
                                char secondString = secondQueue.Peek();
                                if (secondString != '}')
                                {
                                    balanced = false;
                                }
                                else
                                {
                                    firstQueue.Dequeue();
                                    secondQueue.Dequeue();
                                }
                                break;
                            }
                        case '(':
                            {
                                char secondString = secondQueue.Peek();
                                if (secondString != ')')
                                {
                                    balanced = false;
                                }
                                else
                                {
                                    firstQueue.Dequeue();
                                    secondQueue.Dequeue();
                                }
                                break;
                            }
                        case '[':
                            {
                                char secondString = secondQueue.Peek();
                                if (secondString != ']')
                                {
                                    balanced = false;
                                }
                                else
                                {
                                    firstQueue.Dequeue();
                                    secondQueue.Dequeue();
                                }
                                break;
                            }
                        case ' ':
                            {
                                char secondString = secondQueue.Peek();
                                if (secondString != ' ')
                                {
                                    balanced = false;
                                }
                                else
                                {
                                    firstQueue.Dequeue();
                                    secondQueue.Dequeue();
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
                if (balanced)
                {
                    Console.WriteLine("YES");
                }
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}