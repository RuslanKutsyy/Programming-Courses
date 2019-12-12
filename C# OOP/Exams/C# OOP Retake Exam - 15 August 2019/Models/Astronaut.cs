using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get { return this.oxygen; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath
        {
            get
            {
                if (this.Oxygen <= 0)
                {
                    return false;
                }
                return true;
            }
        }

        public IBag Bag
        {
            get { return this.bag; }
        }

        public virtual void Breath()
        {
            if (this.Oxygen - 10 > 0)
            {
                this.Oxygen -= 10;
            }
            else
            {
                this.Oxygen -= this.Oxygen;
            }
        }
    }
}
