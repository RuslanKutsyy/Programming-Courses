using SpaceStation.Core;
using SpaceStation.Core.Contracts;
using SpaceStation.Models;

namespace SpaceStation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}