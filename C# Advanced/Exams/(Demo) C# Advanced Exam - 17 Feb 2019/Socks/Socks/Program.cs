using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> leftSocks = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> rightSocks = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            List<int> paires = new List<int>();

            while (true)
            {
                if (leftSocks.Count == 0 || rightSocks.Count == 0)
                {
                    break;
                }

                int leftSock = leftSocks.Peek();
                int rightSock = rightSocks.Peek();

                if (leftSock > rightSock)
                {
                    paires.Add(leftSock + rightSock);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                    continue;
                }
                else if (rightSock > leftSock)
                {
                    leftSocks.Pop();
                    while (true)
                    {
                        if (leftSocks.Count == 0 || rightSocks.Count == 0)
                        {
                            break;
                        }
                        leftSock = leftSocks.Peek();
                        rightSock = rightSocks.Peek();
                        if (leftSock >= rightSock)
                        {
                            break;
                        }
                        leftSocks.Pop();
                    }
                }
                else if (leftSock == rightSock)
                {
                    rightSocks.Dequeue();
                    var data = leftSocks.ToArray();
                    data[0]++;
                    leftSocks = new Stack<int>(data.Reverse());
                }
            }

            Console.WriteLine(paires.Max());
            Console.WriteLine(string.Join(" ", paires));
        }
    }
}
