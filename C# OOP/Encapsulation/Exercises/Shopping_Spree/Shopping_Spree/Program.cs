using System;
using System.Linq;

namespace Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            ShopQueue Queue = new ShopQueue();
            Queue.AddToQueue(input);

            string productsData = Console.ReadLine();
            ProductCart Cart = new ProductCart();
            Cart.AddToCart(productsData);

            foreach (var person in Queue)
            {
                for (int cartItem = 0; cartItem < Queue.Count; cartItem++)
                {
                    if (person.Money >= Cart[cartItem].Cost)
                    {
                        person.Bag.Add(Cart[cartItem]);
                        person.Money -= Cart[cartItem].Cost;
                        Console.WriteLine($"{person.Name} bought {Cart[cartItem].Name}");
                    }
                }
            }



            
        }
    }
}
