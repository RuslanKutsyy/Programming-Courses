using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Cake : Dessert
    {
        private double cakePrice;

        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams, calories)
        {
            this.Grams = 250;
            this.Calories = 1000;
            this.cakePrice = 5;
        }

        public double CakePrice
        {
            get { return this.cakePrice; }
            set { this.cakePrice = value; }
        }
    }
}
