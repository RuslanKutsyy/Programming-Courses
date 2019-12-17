using System;
using System.Collections.Generic;
using System.Text;

namespace Christmas
{
    public class Present
    {
        public string Name { get; }
        public double Weight { get; }
        public string Gender { get; }

        public Present(string name, double weight, string gender)
        {
            this.Name = name;
            this.Weight = weight;
            this.Gender = gender;
        }

        public override string ToString()
        {
            return $"Present {this.Name} ({this.Weight}) for a {this.Gender}";
        }
    }
}
