using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using SpaceStation.Models.Planets;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;

        public IReadOnlyCollection<IPlanet> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public SerializationInfo ExceptionMessage { get; private set; }

        public void Add(IPlanet model)
        {
            string name = model.Name;
            if (model != null)
            {
                bool exists = this.models.Exists(x => x.Name == name);
                if (!exists)
                {
                    this.models.Add(model);
                }
            }
        }

        public IPlanet FindByName(string name)
        {
            var planet = this.models.Where(x => x.Name == name).FirstOrDefault();

            return planet;
        }

        public bool Remove(IPlanet model)
        {
            string name = model.Name;
            if (model != null)
            {
                bool exists = this.models.Exists(x => x.Name == name);
                if (exists)
                {
                    this.models.Remove(model);
                    return true;
                }
            }
            return false;
        }
    }
}
