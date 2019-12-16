using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummerCocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredientValues = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> freshnessValues = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Dictionary<string, int> cocktails = new Dictionary<string, int>();

            while (true)
            {
                if (ingredientValues.Count == 0 || freshnessValues.Count == 0)
                {
                    break;
                }

                int ingredient = ingredientValues.Peek();
                int fresh = freshnessValues.Peek();

                if (ingredient == 0)
                {
                    ingredientValues.Dequeue();
                    continue;
                }

                int level = ingredient * fresh;

                if (level == 150)
                {
                    ingredientValues.Dequeue();
                    freshnessValues.Pop();
                    if (cocktails.ContainsKey("Mimosa"))
                    {
                        cocktails["Mimosa"]++;
                    }
                    else
                    {
                        cocktails.Add("Mimosa", 1);
                    }
                }
                else if (level == 250)
                {
                    ingredientValues.Dequeue();
                    freshnessValues.Pop();
                    if (cocktails.ContainsKey("Daiquiri"))
                    {
                        cocktails["Daiquiri"]++;
                    }
                    else
                    {
                        cocktails.Add("Daiquiri", 1);
                    }
                }
                else if (level == 300)
                {
                    ingredientValues.Dequeue();
                    freshnessValues.Pop();
                    if (cocktails.ContainsKey("Sunshine"))
                    {
                        cocktails["Sunshine"]++;
                    }
                    else
                    {
                        cocktails.Add("Sunshine", 1);
                    }
                }
                else if (level == 400)
                {
                    ingredientValues.Dequeue();
                    freshnessValues.Pop();
                    if (cocktails.ContainsKey("Mojito"))
                    {
                        cocktails["Mojito"]++;
                    }
                    else
                    {
                        cocktails.Add("Mojito", 1);
                    }
                }
                else
                {
                    freshnessValues.Pop();
                    ingredientValues.Dequeue();
                    ingredientValues.Enqueue(ingredient + 5);
                }
            }

            StringBuilder sb = new StringBuilder();

            if (cocktails.Count == 4)
            {
                sb.AppendLine("It's party time! The cocktails are ready!");
                if (ingredientValues.Count > 0)
                {
                    sb.AppendLine($"Ingredients left: {ingredientValues.Sum()}");
                }

                foreach (var item in cocktails.OrderBy(x => x.Key))
                {
                    sb.AppendLine($" # {item.Key} --> {item.Value}");
                }
            }
            else
            {
                sb.AppendLine("What a pity! You didn't manage to prepare all cocktails.");
                if (ingredientValues.Count > 0)
                {
                    sb.AppendLine($"Ingredients left: {ingredientValues.Sum()}");
                }
                foreach (var item in cocktails)
                {
                    sb.AppendLine($" # {item.Key} --> {item.Value}");
                }
            }

            Console.WriteLine(sb.ToString().Trim());

        }
    }
}
