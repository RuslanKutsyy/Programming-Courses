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
        private ICollection<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
        {
            get
            {
                List<IAstronaut> data = this.models.ToList();
                return data.AsReadOnly();
            }
        }

        public void Add(IAstronaut model)
        {
            if (model == null)
            {
                string name = model.Name;
                List<IAstronaut> data = this.models.ToList();
                bool exists = data.Exists(x => x.Name == name);

                if (!exists)
                {
                    this.models.Add(model);
                }
                else
                {

                }
            }
            
        }

        public IAstronaut FindByName(string name)
        {
            var astronaut = this.models.Where(x => x.Name == name).FirstOrDefault();
            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            string name = model.Name;
            List<IAstronaut> data = this.models.ToList();
            bool exists = data.Exists(x => x.Name == name);

            if (exists)
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
