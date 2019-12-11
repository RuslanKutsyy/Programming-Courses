using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public class Biologist : Astronaut, IAstronaut
    {
        private const double oxygen = 70;

        public Biologist(string name) : base(name, oxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 < 0)
            {
                this.Oxygen -= this.Oxygen;
            }
            else
            {
                this.Oxygen -= 5;
            }
        }
    }
}
