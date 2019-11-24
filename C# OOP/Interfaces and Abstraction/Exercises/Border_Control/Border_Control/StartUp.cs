using System;
using System.Linq;

namespace Border_Control
{
    class StartUp
    {
        static void Main(string[] args)
        {
            City city = new City();
            string cmd = Console.ReadLine();

            while (cmd != "End")
            {
                var data = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 2)
                {
                    string model = data[0];
                    string id = data[1];

                    Robot robot = new Robot(model, id);

                    city.Robots.Add(robot);
                }
                else if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];

                    Citizen citizen = new Citizen(id, name, age);

                    city.Citizens.Add(citizen);
                }

                cmd = Console.ReadLine();
            }

            string fakeIDs = Console.ReadLine();

            Console.Write(city.FakeCheck(fakeIDs));
        }
    }
}
