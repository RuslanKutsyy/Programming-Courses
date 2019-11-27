using System;
using System.Collections.Generic;

namespace Military_Elite
{
    class Program
    {
        static void Main(string[] args)
        {
            Troops troops = new Troops();

            List<Private> privates = new List<Private>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    break;
                }

                var data = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string id = data[1];
                string firstName = data[2];
                string lastName = data[3];

                if (cmd.StartsWith("Private"))
                {
                    decimal salary = decimal.Parse(data[4]);

                    Private privateSoldier = new Private(id, firstName, lastName, salary);
                    privates.Add(privateSoldier);
                }
                else if (cmd.StartsWith("LieutenantGeneral"))
                {
                    decimal salary = decimal.Parse(data[4]);

                    LieutenantGeneral soldier = new LieutenantGeneral(id, firstName, lastName, salary);

                    troops.soldiers.Add(soldier);

                    for (int i = 5; i < data.Length; i++)
                    {
                        string privateId = data[i];

                        for (int privatesNum = 0; privatesNum < privates.Count; privatesNum++)
                        {
                            if (privates[privatesNum].ID == privateId)
                            {
                                soldier.Privates.Add(privates[privatesNum]);
                                privates.RemoveAt(privatesNum);
                            }
                        }
                    }
                }
                else if (cmd.StartsWith("Engineer"))
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                    troops.soldiers.Add(engineer);

                    for (int i = 6; i < data.Length; i += 2)
                    {
                        string part = data[i];
                        int hours = int.Parse(data[i + 1]);
                        Repair repair = new Repair(part, hours);
                        engineer.Repairs.Add(repair);
                    }
                }
                else if (cmd.StartsWith("Commando"))
                {
                    decimal salary = decimal.Parse(data[4]);
                    string corps = data[5];

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);
                    troops.soldiers.Add(commando);

                    for (int i = 6; i < data.Length; i+=2)
                    {
                        string code = data[i];
                        string state = data[i + 1];

                        Mission mission = new Mission(code, state);
                        commando.Missions.Add(mission);
                    }
                }
                else if (cmd.StartsWith("Spy"))
                {
                    int codeNumber = int.Parse(data[3]);

                    Spy spy = new Spy(codeNumber, id, firstName, lastName);

                    troops.soldiers.Add(spy);
                }
            }

            Console.WriteLine(troops.ToString());
        }
    }
}
