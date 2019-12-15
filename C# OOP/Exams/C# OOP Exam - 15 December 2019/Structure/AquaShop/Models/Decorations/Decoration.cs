using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        public Decoration(int comfort, decimal price)
        {
            this.comfort = comfort;
            this.price = price;
        }

        public int Comfort
        {
            get { return this.comfort; }
        }

        public decimal Price
        {
            get { return this.price; }
        }
    }
}
