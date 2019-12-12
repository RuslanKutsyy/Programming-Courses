using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public IReadOnlyCollection<IAstronaut> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(IAstronaut model)
        {
            if (model != null)
            {
                string name = model.Name;
                bool exists = this.models.Exists(x => x.Name == name);

                if (!exists)
                {
                    this.models.Add(model);
                }
            }
            throw new ArgumentException(ExceptionMessages.InvalidAstronautName);
        }

        public IAstronaut FindByName(string name)
        {
            var astronaut = this.models.Where(x => x.Name == name).FirstOrDefault();
            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            string name = model.Name;
            bool exists = this.models.Exists(x => x.Name == name);

            if (exists)
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
