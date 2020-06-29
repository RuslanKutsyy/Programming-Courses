using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> Roaster;

        public string Name { get;}
        public int Capacity { get;}

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roaster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (this.Roaster.Count < this.Capacity)
            {
                this.Roaster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return this.Roaster.Remove(this.Roaster.Where(x => x.Name == name).FirstOrDefault());
        }

        public void PromotePlayer(string name)
        {
            var firstPlayer = this.Roaster.Where(x => x.Name == name).FirstOrDefault();
            if (firstPlayer.Rank != "Member")
            {
                firstPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            var firstPlayer = this.Roaster.Where(x => x.Name == name).FirstOrDefault();
            if (firstPlayer.Rank != "Trial")
            {
                firstPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string Class)
        {
            List<Player> list = new List<Player>();
            for (int i = 0; i < this.Roaster.Count; i++)
            {
                if (this.Roaster[i].Class == Class)
                {
                    list.Add(this.Roaster[i]);
                    this.Roaster.RemoveAt(i);
                }
            }

            return list.ToArray();
        }

        public int Count
        {
            get
            {
                return this.Roaster.Count;
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.Roaster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
