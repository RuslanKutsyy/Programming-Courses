namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using MortalEngines.Common;
    using System;

    public class MachinesManager : IMachinesManager
    {
        private IDictionary<string, IPilot> pilots;
        private IDictionary<string, IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new Dictionary<string, IPilot>();
            this.machines = new Dictionary<string, IMachine>();
        }

        public IDictionary<string, IPilot> Pilots
        {
            get { return this.pilots; }
            private set { this.pilots = value; }
        }

        public IDictionary<string, IMachine> Machines
        {
            get { return this.machines; }
            private set { this.machines = value; }

        }

        public string HirePilot(string name)
        {
            

            if (!this.pilots.ContainsKey(name))
            {
                Pilot pilot = new Pilot(name);
                this.pilots.Add(name, pilot);

                return string.Format(OutputMessages.PilotHired, name);
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.PilotExists, name));
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (!this.Machines.ContainsKey(name))
            {
                IMachine tank = new Tank(name, attackPoints, defensePoints, 100);
                this.Machines.Add(name, tank);
                return string.Format(OutputMessages.TankManufactured, name, attackPoints, defensePoints);
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.MachineExists, name));
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (!this.Machines.ContainsKey(name))
            {
                IMachine fighter = new Fighter(name, attackPoints, defensePoints, 200);
                this.Machines.Add(name, fighter);
                return string.Format(OutputMessages.FighterManufactured, name, attackPoints, defensePoints, (fighter as Fighter).AggressiveMode);
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.MachineExists, name));
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            
        }

        public string PilotReport(string pilotReporting)
        {
            if (this.Pilots.ContainsKey(pilotReporting))
            {
                return this.Pilots[pilotReporting].Report();
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.PilotNotFound, pilotReporting));
            }
        }

        public string MachineReport(string machineName)
        {
            if (this.Machines.ContainsKey(machineName))
            {
                return this.Machines[machineName].ToString();
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.MachineNotFound, machineName));
            }
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.Machines.ContainsKey(fighterName))
            {
                (this.Machines[fighterName] as Fighter).ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.MachineNotFound, fighterName));
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.Machines.ContainsKey(tankName))
            {
                (this.Machines[tankName] as Tank).ToggleDefenseMode();

                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
            else
            {
                throw new Exception(string.Format(OutputMessages.MachineNotFound, tankName));
            }
        }
    }
}