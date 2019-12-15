using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models
        {
            get { return this.models.AsReadOnly(); }
        }

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decor = this.models.Where(x => x.GetType().Name == type).FirstOrDefault();

            return decor;
        }

        public bool Remove(IDecoration model)
        {
            var decor = this.models.Where(x => x.Comfort == model.Comfort && x.Price == model.Price).FirstOrDefault();

            if (decor == null)
            {
                return false;
            }

            this.models.Remove(model);
            return true;
        }
    }
}
