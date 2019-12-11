using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Meteorologist : Astronaut, IAstronaut
    {
        private const double oxygen = 90;

        public Meteorologist(string name) : base(name, oxygen)
        {
        }
    }
}
