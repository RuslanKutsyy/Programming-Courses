using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> mammals = new List<IBuyer>();
            List<Robot> robots = new List<Robot>();

            int num = int.Parse(Console.ReadLine());
            int boughtfood = 0;

            for (int i = 0; i < num; i++)
            {
                var data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    mammals.Add(rebel);
                }
                else if (data.Length == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string group = data[3];

                    IBuyer citizen = new Citizen(name, age, id, group);
                    mammals.Add(citizen);
                }
            }

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "End")
                {
                    break;
                }

                for (int i = 0; i < mammals.Count; i++)
                {
                    if (mammals[i].Name == cmd)
                    {
                        boughtfood += mammals[i].BuyFood();
                    }
                }
            }

            Console.WriteLine(boughtfood);
        }
    }
}
