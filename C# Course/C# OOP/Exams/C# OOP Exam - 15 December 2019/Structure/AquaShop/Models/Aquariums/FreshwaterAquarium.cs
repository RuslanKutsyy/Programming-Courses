using AquaShop.Models.Aquariums.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public class FreshwaterAquarium : Aquarium, IAquarium
    {
        private const int capacity = 50;

        public FreshwaterAquarium(string name) : base(name, capacity)
        {
        }
    }
}
