using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> data;

        public PlayerRepository()
        {
            this.data = new Dictionary<string, IPlayer>();
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get
            {
                IReadOnlyCollection<IPlayer> players = this.data.Values.ToList().AsReadOnly();
                return players;
            }
        }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            this.data.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            if (this.data.ContainsKey(username))
            {
                return this.data[username];
            }
            return null;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.data.ContainsKey(player.Username))
            {
                this.data.Remove(player.Username);
                return true;
            }
            return false;
        }
    }
}
