using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpaceStation
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                List<string> items = planet.Items.ToList();
                for (int itemNum = 0; itemNum < planet.Items.Count; itemNum++)
                {
                    if (astronaut.Oxygen > 0)
                    {
                        astronaut.Bag.Items.Add(items[itemNum]);
                        items.Remove(items[itemNum]);
                        astronaut.Breath();
                    }

                    if (astronaut.Oxygen <= 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
