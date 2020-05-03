using System;
using System.Collections.Generic;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ");
            string command = Console.ReadLine();
            var queue = new Queue<string>(songs);

            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }

                var commandAsArr = command.Split();
                string cmd = commandAsArr[0];
                switch (cmd)
                {
                    case "Play":
                        {
                            queue.Dequeue();
                            break;
                        }
                    case "Add":
                        {
                            string songToAdd = command.Replace("Add ", "");
                            if (!queue.Contains(songToAdd))
                            {
                                queue.Enqueue(songToAdd);
                            }
                            else
                            {
                                Console.WriteLine($"{songToAdd} is already contained!");
                            }
                            break;
                        }
                    case "Show":
                        {
                            Console.WriteLine(String.Join(", ", queue));
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
