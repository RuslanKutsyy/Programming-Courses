using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoint;
        private int healthPoints;

        public Card(string name, int damagePoints, int healthPoints)
        {
            this.name = name;
            this.damagePoint = damagePoints;
            this.healthPoints = healthPoints;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int DamagePoints
        {
            get { return this.damagePoint; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }
                this.damagePoint = value;
            }
        }

        public int HealthPoints
        {
            get { return this.healthPoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }
                this.healthPoints = value;
            }
        }
    }
}
