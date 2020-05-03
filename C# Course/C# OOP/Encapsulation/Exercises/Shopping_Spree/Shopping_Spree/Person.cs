using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    class Person
    {
        private string name;
        private double money;
        private List<Product> bag;

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.bag = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public List<Product> Bag
        {
            get { return this.bag; }
            set { this.bag = value; }
        }
    }
}
