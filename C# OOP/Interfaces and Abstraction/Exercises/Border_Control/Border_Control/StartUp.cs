using System;
using System.Linq;
using System.Collections.Generic;

namespace Border_Control
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> all = new List<IIdentifiable>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    break;
                }

                var data = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 2)
                {
                    string model = data[0];
                    string id = data[1];

                    Robot robot = new Robot(model, id);
                    all.Add(robot);
                }
                else if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];

                    Citizen citizen = new Citizen(name, age, id);

                    all.Add(citizen);
                }
            }

            string fake = Console.ReadLine();
            var filteredAll = all.Where(x => x.Id.EndsWith(fake)).ToList();

            if (filteredAll.Count > 0)
            {
                foreach (var one in filteredAll)
                {
                    Console.WriteLine(one.Id);
                }
            }
        }
    }
}
