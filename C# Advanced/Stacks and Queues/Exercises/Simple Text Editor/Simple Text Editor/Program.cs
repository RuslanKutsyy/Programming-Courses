using System;
using System.Collections.Generic;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());
            string mainText = string.Empty;
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < operations; i++)
            {
                string[] command = Console.ReadLine().Split();
                string cmdType = command[0];

                switch (cmdType)
                {
                    case "1":
                        {
                            mainText += command[1];
                            stack.Push(mainText);
                            break;
                        }
                    case "2":
                        {
                            int numOfElements = int.Parse(command[1]);
                            mainText = mainText.Remove(mainText.Length - numOfElements);
                            stack.Push(mainText);
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(mainText[int.Parse(command[1]) - 1]);
                            break;
                        }
                    case "4":
                        {
                            string temp = stack.Peek();
                            if (temp == mainText)
                            {
                                stack.Pop();
                            }
                            mainText = stack.Pop();
                            break;
                        }
                    default:
                        break;
                }
            }
            
        }
    }
}
