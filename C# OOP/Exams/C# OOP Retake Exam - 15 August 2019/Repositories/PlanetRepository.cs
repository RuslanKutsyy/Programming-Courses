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
        private ICollection<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
        {
            get
            {
                List<IPlanet> data = this.models.ToList();
                return data.AsReadOnly();
            }
        }

        public void Add(IPlanet model)
        {
            string name = model.Name;
            if (model != null)
            {
                List<IPlanet> data = this.models.ToList();
                bool exists = data.Exists(x => x.Name == name);
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
                List<IPlanet> data = this.models.ToList();
                bool exists = data.Exists(x => x.Name == name);
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
