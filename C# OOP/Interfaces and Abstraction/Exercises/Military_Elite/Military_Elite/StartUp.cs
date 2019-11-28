using System;
using System.Collections.Generic;
using Military_Elite.Interfaces;
using Military_Elite.Emums;
using System.Linq;
using Military_Elite.Models;

namespace Military_Elite
{
    class Program
    {
        static void Main(string[] args)
        {
            var troops = new Dictionary<string, ISoldier>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    break;
                }

                var data = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierType = data[0];
                string id = data[1];
                string firstName = data[2];
                string lastName = data[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(data[4]);

                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(data[4]);

                    var privates = new Dictionary<string, IPrivate>();

                    for (int i = 5; i < data.Length; i++)
                    {
                        string privateId = data[i];
                        var currentSoldier = (IPrivate)troops[privateId];
                        privates.Add(privateId, currentSoldier);
                    }
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (soldierType ==  "Engineer")
                {
                    decimal salary = decimal.Parse(data[4]);
                    bool isValidCorps = Enum.TryParse(data[5], out Corps corps);

                    if (isValidCorps)
                    {
                        ICollection<IRepair> repairs = new List<IRepair>();

                        for (int i = 6; i < data.Length; i += 2)
                        {
                            string part = data[i];
                            int hours = int.Parse(data[i + 1]);
                            IRepair repair = new Repair(part, hours);
                            repairs.Add(repair);
                        }

                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(data[4]);
                    bool isValidCorps = Enum.TryParse(data[5], out Corps corps);

                    if (isValidCorps)
                    {
                        ICollection<IMission> missions = new List<IMission>();

                        for (int i = 6; i < data.Length; i += 2)
                        {
                            string code = data[i];
                            string missionState = data[i + 1];

                            bool isValidState = Enum.TryParse(missionState, out State state);

                            if (!isValidState)
                            {
                                continue;
                            }

                            IMission mission = new Mission(code, state);
                            missions.Add(mission);
                        }

                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(data[4]);

                    soldier = new Spy(codeNumber, id, firstName, lastName);
                }

                if (soldier != null)
                {
                    Console.WriteLine(soldier);
                    troops.Add(id, soldier);
                }
            }
        }
    }
}
