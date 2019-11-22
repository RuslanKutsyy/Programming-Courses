using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Calories
{
    class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string pizzaName)
        {
            this.Name = pizzaName;
            this.toppings = new List<Topping>();
            //this.dough = new Dough(doughType, bakingTechnique, weight);
            //this.toppings = new List<Topping>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) && value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        private List<Topping> Toppings
        {
            get { return this.toppings; }
            set
            {
                if (value.Count > 10)
                {
                    throw new Exception("Number of toppings should be in range [0..10].");
                }
                this.toppings = value;
            }
        } 

        public Dough Dough
        {
            get { return this.dough; }
            set
            {
                this.dough = value ?? throw new Exception("Invalid type of dough.");
            }
        }

        public int NumberOfToppings()
        {
            return this.toppings.Count;
        }

        public double GetTotalCalories()
        {
            double calories = this.dough.GetCalories();
            foreach (var topping in toppings)
            {
                calories += topping.GetCalories();
            }

            return calories;
        }

        public void AddToppings(Topping topping)
        {
            if (this.Toppings.Count + 1 > 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            this.Toppings.Add(topping);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} - {GetTotalCalories():F2} Calories.");

            return sb.ToString();
        }
    }
}
