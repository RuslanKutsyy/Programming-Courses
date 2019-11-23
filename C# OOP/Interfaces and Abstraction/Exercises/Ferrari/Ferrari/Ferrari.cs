using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        public string Model { get; set; }
        public string Driver { get; set; }

        public Ferrari(string name)
        {
            this.Model = "488-Spider";
            this.Driver = name;
        }

        public string Brake()
        {
            string output = "Brakes!";
            return output;            
        }

        public string Gas()
        {
            string output = "Gas!";
            return output;
        }

        public override string ToString()
        {
            string output = $"{this.Model}/{this.Brake()}/{this.Gas()}/{this.Driver}";
            return output.ToString();
        }
    }
}
