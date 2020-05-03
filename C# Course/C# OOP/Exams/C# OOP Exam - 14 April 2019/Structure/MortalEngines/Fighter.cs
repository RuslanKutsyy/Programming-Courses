using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines
{
    public class Fighter : BaseMachine, IFighter
    {
        private bool aggressiveMode;

        public Fighter(string name, double attackPoints, double defensePoints, double healthPoints) : base(name, attackPoints, defensePoints, healthPoints)
        {
            this.HealthPoints = 200;
            this.aggressiveMode = true;
        }

        public bool AggressiveMode
        {
            get { return this.aggressiveMode; }
            private set { this.aggressiveMode = value; }
        }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;

                if (this.AttackPoints - 50 < 0)
                {
                    this.AttackPoints = 0;
                }
                else
                {
                    this.AttackPoints -= 50;
                }

                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                if (this.DefensePoints - 25 < 0)
                {
                    this.DefensePoints = 0;
                }
                else
                {
                    this.DefensePoints -= 25;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.AggressiveMode)
            {
                sb.Append(" *Aggressive: ON");
            }
            else
            {
                sb.Append(" *Aggressive: OFF");
            }
            return sb.ToString().Trim();
        }
    }
}
