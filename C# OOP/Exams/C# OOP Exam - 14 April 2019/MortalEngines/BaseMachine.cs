using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IList<string> targets;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Machine name cannot be null or empty.");
            }
            this.name = name;

            if (attackPoints <= 0)
            {
                throw new ArgumentException("Attack Points cannot be less than 0");
            }
            this.attackPoints = attackPoints;

            if (defensePoints <= 0)
            {
                throw new ArgumentException("Defense Points cannot be less than 0");
            }
            this.defensePoints = defensePoints;

            if (healthPoints <= 0)
            {
                throw new ArgumentException("Health Points cannot be less than 0");
            }
            this.healthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");

                }
                this.pilot = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            set { this.defensePoints = value; }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set { this.healthPoints = value; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
            private set { this.targets = value; }
        }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double damage = this.AttackPoints - target.DefensePoints;
            if (damage < 0)
            {
                damage = 0;
            }

            target.HealthPoints -= damage;
            this.Targets.Add(target.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType()}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            sb.AppendLine(" *Targets: ");
            if (this.Targets.Count == 0)
            {
                sb.Append("None");
            }
            else
            {
                sb.Append(string.Join(',', this.Targets));
            }

            return sb.ToString().Trim();
        }

    }
}
