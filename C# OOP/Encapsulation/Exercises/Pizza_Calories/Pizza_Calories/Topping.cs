using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories
{
    class Topping
    {
        private const int CaloriesPerGramm = 2;
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get { return this.type; }
            set
            {
                if (value[0] != char.ToUpper(value[0]))
                {
                    value = value.Replace(value[0], char.ToUpper(value[0]));
                }

                if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range[1..50].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double calories = CaloriesPerGramm * this.Weight * GetModifier(this.Type);

            return calories;
        }

        private double GetModifier(string toppingType)
        {
            switch (toppingType)
            {
                case "Meat": return 1.2;
                case "Veggies": return 0.8;
                case "Cheese": return 1.1;
                case "Sauce": return 0.9;
                default:
                    return -1;
            }
        }
    }
}
