using System;
using System.Collections.Generic;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string text = string.Empty;
            var stack = new Stack<string>();

            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split();
                string action = input[0];

                switch (action)
                {
                    case "1":
                        {
                            string items = input[1];
                            stack.Push(text);
                            text += items;
                            break;
                        }
                    case "2":
                        {
                            string items = input[1];
                            stack.Push(text);
                            int numberOfCharsToRemove = int.Parse(items);
                            if (text.Length > numberOfCharsToRemove)
                            {
                                text = text.Substring(0, text.Length - numberOfCharsToRemove);
                            }
                            else
                            {
                                text = string.Empty;
                            }
                            break;
                        }
                    case "3":
                        {
                            string items = input[1];
                            int positionToPrint = int.Parse(items);
                            if (text.Length>=positionToPrint)
                            {
                                Console.WriteLine(text[positionToPrint-1]);
                            }
                            break;
                        }
                    case "4":
                        {
                            text = stack.Pop();
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
