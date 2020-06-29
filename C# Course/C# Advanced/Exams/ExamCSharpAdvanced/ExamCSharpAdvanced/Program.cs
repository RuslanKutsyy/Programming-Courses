using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamCSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            var sumCollection = 0;
            Queue<int> firstLootBoxNums = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            Stack<int> secondLootBoxNums = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            while (firstLootBoxNums.Count != 0 || secondLootBoxNums.Count != 0)
            {
                if (firstLootBoxNums.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                else if (secondLootBoxNums.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }

                int firstNum = firstLootBoxNums.Peek();
                int secondNum = secondLootBoxNums.Peek();

                if ((firstNum + secondNum) % 2 == 0)
                {
                    firstLootBoxNums.Dequeue();
                    secondLootBoxNums.Pop();
                    sumCollection += firstNum + secondNum;
                }
                else
                {
                    firstLootBoxNums.Enqueue(secondNum);
                    secondLootBoxNums.Pop();
                }
            }

            if (sumCollection > 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumCollection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumCollection}");
            }
        }
    }
}
