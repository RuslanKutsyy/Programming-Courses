using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IMammal> mammals = new List<IMammal>();
            List<Robot> robots = new List<Robot>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    break;
                }

                var data = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (data[0] == "Robot")
                {
                    string model = data[1];
                    string id = data[2];

                    Robot robot = new Robot(model, id);
                    robots.Add(robot);
                }
                else if (data[0] == "Citizen")
                {
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string date = data[4];

                    IMammal citizen = new Citizen(name, age, id, date);

                    mammals.Add(citizen);
                }
                else if (data[0] == "Pet")
                {
                    string name = data[1];
                    string birthdayDate = data[2];
                    IMammal pet = new Pet(name, birthdayDate);
                    mammals.Add(pet);
                }
            }

            string year = Console.ReadLine();

            mammals.Where(x => x.BirthdayDate.EndsWith(year)).Select(x => x.BirthdayDate).ToList().ForEach(Console.WriteLine);
        }
    }
}
