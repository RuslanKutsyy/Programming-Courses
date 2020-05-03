using System;

namespace Pizza_Calories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cmd = Console.ReadLine();
                string pizzaName = string.Empty;
                string doughType = string.Empty;
                string bakingTechnique = string.Empty;
                double doughWeight = 0;
                string toppingType = string.Empty;
                double toppingWeight = 0;

                var data = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (data[0] == "Pizza")
                {
                    pizzaName = data[1];
                }

                Pizza pizza = new Pizza(pizzaName);

                data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Dough")
                {
                    doughType = data[1];
                    bakingTechnique = data[2];
                    doughWeight = double.Parse(data[3]);
                    Dough dough = new Dough(doughType, bakingTechnique, doughWeight);
                    pizza.Dough = dough;
                }

                cmd = Console.ReadLine();
                while (cmd != "END")
                {
                    data = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    if (data[0] == "Topping")
                    {
                        toppingType = data[1];
                        toppingWeight = double.Parse(data[2]);
                        var topping = new Topping(toppingType, toppingWeight);
                        pizza.AddToppings(topping);
                    }

                    cmd = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
