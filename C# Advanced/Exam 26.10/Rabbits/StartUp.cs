namespace Rabbits
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Cage cage = new Cage("Wildness", 20);
            //Initialize entity
            Rabbit rabbit = new Rabbit("Fluffy", "Blanc de Hotot");
            //Print Rabbit
            Console.WriteLine(rabbit); //Rabbit (Blanc de Hotot): Fluffy

            //Add Rabbit
            cage.Add(rabbit);
            Console.WriteLine(cage.Count); //1

        }
    }
}
