using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Backpack : IBag
    {
        private ICollection<string> items;

        public Backpack()
        {
            this.items = new List<string>();
        }

        public ICollection<string> Items
        {
            get { return this.items; }
        }
    }
}
