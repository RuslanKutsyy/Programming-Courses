using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Christmas
{
    public class Bag
    {
        public List<Present> data { get; private set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        
        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            var present = this.data.Where(x => x.Name == name).FirstOrDefault();

            if (present == null)
            {
                return false;
            }
            this.data.Remove(present);
            return true;
        }

        public Present GetHeaviestPresent()
        {
            var present = this.data.OrderByDescending(x => x.Weight).FirstOrDefault();

            return present;
        }

        public Present GetPresent(string name)
        {
            var present = this.data.Where(x => x.Name == name).FirstOrDefault();

            return present;
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
