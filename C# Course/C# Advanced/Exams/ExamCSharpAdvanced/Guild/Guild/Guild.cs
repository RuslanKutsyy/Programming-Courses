using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity && !this.roster.Any(x => x.Name == player.Name))
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string playerName)
        {
            return this.roster.Remove(this.roster.Where(x => x.Name == playerName).FirstOrDefault());
        }

        public void PromotePlayer(string playerName)
        {
            var firstPlayer = this.roster.Where(x => x.Name == playerName).FirstOrDefault();
            if (firstPlayer != null && firstPlayer.Rank != "Member")
            {
                firstPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string playerName)
        {
            var firstPlayer = this.roster.Where(x => x.Name == playerName).FirstOrDefault();
            if (firstPlayer != null && firstPlayer.Rank != "Trial")
            {
                firstPlayer.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string className)
        {
            Player[] arr = this.roster.Where(x => x.Class == className).ToArray();
            this.roster = this.roster.Where(x => x.Class != className).ToList();

            return arr;
        }

        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
