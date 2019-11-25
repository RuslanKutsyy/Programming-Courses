using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Commando : ICommando
    {
        public List<Mission> Missions { get; set; }

        public Commando()
        {
            this.Missions = new List<Mission>();
        }
    }
}
