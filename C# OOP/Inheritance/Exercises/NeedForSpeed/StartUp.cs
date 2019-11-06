namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle mt = new RaceMotorcycle(13, 33.3);
            System.Console.WriteLine(mt.DefaultFuelConsumption);
        }
    }
}
