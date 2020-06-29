using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public string Name { get;}
        public string Class { get;}

        public string Rank { get; set; }

        public string Description { get; set; }

        public Player(string name, string Class)
        {
            this.Name = name;
            this.Class = Class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Player {this.Name}: {this.Class}");
            sb.AppendLine($"Rank: {this.Rank}");
            sb.AppendLine($"Description: {this.Description}");       

            return sb.ToString().Trim();
        }
    }
}
