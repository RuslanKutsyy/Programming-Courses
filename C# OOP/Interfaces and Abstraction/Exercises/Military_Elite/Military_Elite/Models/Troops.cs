using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Troops
    {
        private List<ISoldier> soldiers { get; set; }

        public Troops()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Add(ISoldier soldier)
        {
            this.soldiers.Add(soldier);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var soldier in soldiers)
            {
                sb.AppendLine(soldier.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
