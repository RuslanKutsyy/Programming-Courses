using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public class Ornament : Decoration, IDecoration
    {
        private const int comfort = 1;
        private const int price = 5;

        public Ornament() : base(comfort, price)
        {
        }
    }
}
