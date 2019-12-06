using MortalEngines.Entities.Contracts;
using System;
using System.Text;

namespace MortalEngines
{
    public class Tank : BaseMachine, ITank
    {
        private bool defenseMode;

        public Tank(string name, double attackPoints, double defensePoints, double healthPoints) : base(name, attackPoints, defensePoints, healthPoints)
        {
            this.HealthPoints = 100;
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
            private set { this.defenseMode = value; }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.DefenseMode)
            {
                sb.Append(" *Defense: ON");
            }
            else
            {
                sb.Append(" *Defense: OFF");
            }
            return sb.ToString().Trim();
        }
    }
}