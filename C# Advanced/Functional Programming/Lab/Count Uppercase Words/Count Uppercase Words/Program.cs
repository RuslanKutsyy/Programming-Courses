using System;
using System.Linq;
namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> check = x => x[0] == x.ToUpper()[0];
            var text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(check).ToArray();

            foreach (var word in text)
            {
                Console.WriteLine(word);
            }
        }
    }
}
