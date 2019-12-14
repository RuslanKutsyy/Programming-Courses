using System;
using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private Dictionary<string, IGun> models;

        public GunRepository()
        {
            this.models = new Dictionary<string, IGun>();
        }

        public IReadOnlyCollection<IGun> Models
        {
            get { return this.models.Values.ToList().AsReadOnly(); }
        }

        public void Add(IGun model)
        {
            if (!this.models.ContainsKey(model.Name))
            {
                this.models.Add(model.Name, model);
            }
        }

        public IGun Find(string name)
        {
            return this.models[name];
        }

        public bool Remove(IGun model)
        {
            if (this.models.ContainsKey(model.Name))
            {
                this.models.Remove(model.Name);
                return true;
            }
            return false;
        }
    }
}
