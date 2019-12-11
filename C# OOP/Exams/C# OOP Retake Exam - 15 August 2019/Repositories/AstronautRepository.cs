using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models;

namespace SpaceStation.Repositories
{
    public class AstronautRepository<IAstronaut> : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models
        {
            get { return (this.models).ToList().AsReadOnly(); }
        }

        public void Add(IAstronaut model)
        {
            bool exists = this.models.Select(x => x.)
        }

        public IAstronaut FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IAstronaut model)
        {
            throw new NotImplementedException();
        }
    }
}
