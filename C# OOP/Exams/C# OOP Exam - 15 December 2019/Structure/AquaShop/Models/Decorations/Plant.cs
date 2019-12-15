using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models
{
    public class Plant : Decoration, IDecoration
    {
        private const int comfort = 5;
        private const int price = 10;

        public Plant() : base(comfort, price)
        {
        }
    }
}
