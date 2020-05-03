using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player, IPlayer
    {
        private const int health = 50;
        public Beginner(string username) : base(username, health)
        {
        }
    }
}
