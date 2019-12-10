using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player, IPlayer
    {
        private const int health = 250;

        public Advanced(string username) : base(username, health)
        {
        }
    }
}
