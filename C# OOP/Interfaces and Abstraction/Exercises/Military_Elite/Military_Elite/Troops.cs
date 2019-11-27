using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Troops
    {
        public List<ISoldier> soldiers { get; set; }

        public Troops()
        {
            this.soldiers = new List<ISoldier>();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
