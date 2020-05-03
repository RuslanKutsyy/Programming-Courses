using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * 0.25;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
