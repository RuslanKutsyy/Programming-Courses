using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>(); ;
            string command = Console.ReadLine();

            while (command != "Revision")
            {
                var data = command.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string shopName = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                    shops[shopName].Add(product, price);
                }
                else
                {
                    shops[shopName].Add(product, price);
                }

                command = Console.ReadLine();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine(shop.Key + "->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
