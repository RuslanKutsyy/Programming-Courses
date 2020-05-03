using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Vegetable || food is Meat)
            {
                this.Weight += 0.3 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.Quantity}!");
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
