using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CSharpAdvancedExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
            var bombCasings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)));
            var isPouchFull = false;
            var bombsMap = new Dictionary<string, int>
            {
                ["Datura Bombs"] = 0,
                ["Cherry Bombs"] = 0,
                ["Smoke Decoy Bombs"] = 0
            };

            while (true)
            {
                if (bombEffects.Count == 0 || bombCasings.Count == 0)
                {
                    break;
                }

                if (bombsMap.All(x => x.Value >= 3))
                {
                    isPouchFull = true;
                    break;
                }

                var bombEfElement = bombEffects.Peek();
                var bombCasingElement = bombCasings.Peek();

                var bombMaterial = isSumEnoughForMaterials(bombEfElement + bombCasingElement);

                if (String.IsNullOrEmpty(bombMaterial))
                {
                    var stackAsList = bombCasings.ToList();
                    stackAsList[0] -= 5;
                    stackAsList.Reverse();

                    bombCasings = new Stack<int>(stackAsList);
                }
                else
                {
                    bombsMap[bombMaterial] += 1;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
            }

            var finalMainText = "";
            
            finalMainText += isPouchFull ? "Bene! You have successfully filled the bomb pouch!\n" : "You don't have enough materials to fill the bomb pouch.\n";

            finalMainText += bombEffects.Count > 0 ? $"Bomb Effects: {String.Join(", ", bombEffects)}\n" : "Bomb Effects: empty\n";

            finalMainText += bombCasings.Count > 0 ? $"Bomb Casings: {String.Join(", ", bombCasings)}\n" : "Bomb Casings: empty\n";

            var orderedKeys = bombsMap.Keys.OrderBy(x => x).ToArray();

            for (int i = 0; i < orderedKeys.Count(); i++)
            {
                finalMainText += $"{orderedKeys[i]}: {bombsMap[orderedKeys[i]]}";
                if (i < orderedKeys.Count() - 1)
                {
                    finalMainText += "\n";
                }
            }

            Console.WriteLine(finalMainText);
        }

        public static string isSumEnoughForMaterials(int sum)
        {
            var bombsSumMap = new Dictionary<string, int>
            {
                ["Datura Bombs"] = 40,
                ["Cherry Bombs"] = 60,
                ["Smoke Decoy Bombs"] = 120
            };

            return bombsSumMap.Where(x => x.Value == sum).FirstOrDefault().Key;
        }
    }
}
