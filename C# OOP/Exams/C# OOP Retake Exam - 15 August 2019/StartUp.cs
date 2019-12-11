using SpaceStation.Core;
using SpaceStation.Core.Contracts;
using SpaceStation.Models;

namespace SpaceStation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //IEngine engine = new Engine();
            //engine.Run();

            Biologist astronaut = new Biologist("Ivan");
            System.Console.WriteLine(astronaut.Name, astronaut.Oxygen);
            astronaut.Breath();
            System.Console.WriteLine(astronaut.Oxygen);
        }
    }
}