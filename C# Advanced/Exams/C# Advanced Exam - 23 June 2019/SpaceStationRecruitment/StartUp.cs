using System;

namespace SpaceStationRecruitment
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SpaceStation spaceStation = new SpaceStation("Apolo", 10);

            Astronaut astronaut = new Astronaut("Stephen", 40, "Bulgaria");

            Console.WriteLine(astronaut); //Astronaut: Stephen, 40 (Bulgaria)


            spaceStation.Add(astronaut);

            spaceStation.Remove("Astronaut name"); //false

            Astronaut secondAstronaut = new Astronaut("Mark", 34, "UK");


            spaceStation.Add(secondAstronaut);

            Astronaut oldestAstronaut = spaceStation.GetOldestAstronaut(); // Astronaut with name Stephen
            Astronaut astronautStephen = spaceStation.GetAstronaut("Stephen"); // Astronaut with name Stephen
            Console.WriteLine(oldestAstronaut); //Astronaut: Stephen, 40 (Bulgaria)
            Console.WriteLine(astronautStephen); //Astronaut: Stephen, 40 (Bulgaria)

            Console.WriteLine(spaceStation.Count); //2

            Console.WriteLine(spaceStation.Report());

        }
    }
}
