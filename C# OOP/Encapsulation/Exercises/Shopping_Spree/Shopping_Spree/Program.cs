using System;
using System.Linq;
using System.Text;

namespace Shopping_Spree
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string input = Console.ReadLine();
                ShopQueue Queue = new ShopQueue();
                Queue.AddToQueue(input);

                string productsData = Console.ReadLine();
                ProductCart Cart = new ProductCart();
                Cart.AddToCart(productsData);

                string cmd = Console.ReadLine();

                while (cmd != "END")
                {
                    var data = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0];
                    string prodName = data[1];

                    foreach (var person in Queue.Queue.Where(person => person.Name == name))
                    {
                        foreach (var prod in Cart.Cart.Where(x => x.Name == prodName))
                        {
                            if (prod.Cost <= person.Money)
                            {
                                person.Bag.Add(prod);
                                person.Money -= prod.Cost;
                                Console.WriteLine($"{name} bought {prodName}");
                            }
                            else
                            {
                                Console.WriteLine($"{name} can't afford {prodName}");
                            }
                        }
                    }
                    cmd = Console.ReadLine();
                }

                StringBuilder sb = new StringBuilder();

                foreach (var person in Queue.Queue)
                {
                    if (person.Bag.Count > 0)
                    {
                        sb.Append($"{person.Name} - ");
                        for (int i = 0; i < person.Bag.Count; i++)
                        {
                            sb.Append($"{person.Bag[i].Name}");
                            if (i != person.Bag.Count - 1)
                            {
                                sb.Append(", ");
                            }
                        }
                        sb.AppendLine();
                    }
                    else
                    {
                        sb.Append($"{person.Name} - Nothing bought");
                    }
                }

                Console.WriteLine(sb);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
