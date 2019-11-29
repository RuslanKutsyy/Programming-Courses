using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                this.Weight += 1.00 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
