using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines
{
    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public IList<IMachine> Machines
        {
            get { return this.machines; }
            private set { this.machines = value; }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            this.Machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.Machines.Count} machines");
            foreach (var machine in this.Machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
