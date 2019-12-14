using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player, IPlayer
    {
        private const int lifePoints = 100;
        private const string name = "Tommy Vercetti";

        public MainPlayer() : base(name, lifePoints)
        {
        }
    }
}
