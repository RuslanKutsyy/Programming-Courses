using MortalEngines.Common;
using MortalEngines.Core;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {

            try
            {
                MachinesManager MachineManager = new MachinesManager();
                string command = Console.ReadLine();

                while (command != "Quit")
                {
                    var data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string commandType = data[0];

                    switch (commandType)
                    {
                        case "HirePilot":
                            {
                                string name = data[1];
                                Console.WriteLine(MachineManager.HirePilot(name));
                                break;
                            }
                        case "PilotReport ":
                            {
                                string name = data[1];
                                Console.WriteLine(MachineManager.PilotReport(name));

                                break;
                            }
                        case "ManufactureTank":
                            {
                                string name = data[1];
                                double attackPoints = double.Parse(data[2]);
                                double defensePoints = double.Parse(data[3]);

                                Console.WriteLine(MachineManager.ManufactureTank(name, attackPoints, defensePoints));

                                break;
                            }
                        case "ManufactureFighter":
                            {
                                string name = data[1];
                                double attackPoints = double.Parse(data[2]);
                                double defensePoints = double.Parse(data[3]);

                                Console.WriteLine(MachineManager.ManufactureFighter(name, attackPoints, defensePoints));

                                break;
                            }
                        case "MachineReport":
                            {
                                string name = data[1];

                                Console.WriteLine(MachineManager.MachineReport(name));

                                break;
                            }
                        case "AggressiveMode":
                            {
                                string name = data[1];

                                Console.WriteLine(MachineManager.ToggleFighterAggressiveMode(name));

                                break;
                            }
                        case "DefenseMode":
                            {
                                string name = data[1];

                                Console.WriteLine(MachineManager.ToggleTankDefenseMode(name));
                                break;
                            }
                        case "Engage":
                            {
                                string pilotName = data[1];
                                string machineName = data[2];

                                Console.WriteLine(MachineManager.EngageMachine(pilotName, machineName));

                                break;
                            }
                        case "Attack":
                            {
                                string attackingMachineName = data[1];
                                string defendingMachineName = data[2];

                                Console.WriteLine(MachineManager.AttackMachines(attackingMachineName, defendingMachineName));

                                break;
                            }
                        default:
                            break;
                    }

                    command = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
    }
}