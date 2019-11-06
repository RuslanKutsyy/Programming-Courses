using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Beverage : Product
    {
        private double price { get; set; }
        private double milliliters;

        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            this.price = (double)price;
        }

        public double Milliliters
        {
            get { return this.milliliters; }
            set { this.milliliters = value; }
        }

    }
}
