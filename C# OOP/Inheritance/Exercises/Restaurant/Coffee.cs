using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    class Coffee : HotBeverage
    {
        private const double milliliters = 50;
        private const decimal price = 3.50m;

        public double Caffeine { get; set; }

        public Coffee(string name, double caffein) : base(name, price, milliliters)
        {
            Caffeine = caffein;
        }
    }
}
