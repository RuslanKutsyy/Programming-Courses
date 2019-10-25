using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    class Salad
    {
        private List<Vegetable> products;
        private string name;

        public List<Vegetable> Product
        {
            get { return this.products; }
            set { this.products = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public Salad(string name)
        {
            this.name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            int sum = 0;

            for (int i = 0; i < this.Product.Count; i++)
            {
                sum += this.Product[i].Calories;
            }

            return sum;
        }

        public int GetProductCount()
        {
            return this.Product.Count;
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"* Salad {this.Name} is {GetTotalCalories()} calories and have {GetProductCount()} products:");
            for (int i = 0; i < this.products.Count; i++)
            {
                newSB.AppendLine(this.products[i].ToString());
            }

            return newSB.ToString().Trim();
        }
    }
}
