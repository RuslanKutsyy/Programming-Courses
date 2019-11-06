using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        private double coffeeMilliliters;
        private decimal coffeePrice;
        private double caffein;

        public Coffee(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
            this.coffeeMilliliters = 50;
            this.coffeePrice = 3.50m;
        }

        public double CoffeeMilliliters
        {
            get { return this.coffeeMilliliters; }
            set { this.coffeeMilliliters = value; }
        }

        public decimal CoffeePrice
        {
            get { return this.coffeePrice; }
            set { this.coffeePrice = value; }
        }

        public double Caffein
        {
            get { return this.caffein; }
            set { this.caffein = value; }
        }
    }
}
