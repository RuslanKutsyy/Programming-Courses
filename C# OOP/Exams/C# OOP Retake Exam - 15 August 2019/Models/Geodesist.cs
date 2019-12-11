using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Geodesist : Astronaut, IAstronaut
    {
        private const double oxygen = 50;

        public Geodesist(string name) : base(name, oxygen)
        {
        }
    }
}
