using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.capacity = capacity;
            this.fish = new List<IFish>();
            this.decorations = new List<IDecoration>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int Comfort
        {
            get
            {
                int sum = this.Decorations.Sum(x => x.Comfort);

                return sum;
            }
        }

        public ICollection<IDecoration> Decorations
        {
            get { return this.decorations; }
        }

        public ICollection<IFish> Fish
        {
            get { return this.fish; }
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.capacity)
            {
                throw new InvalidOperationException(OutputMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var AnyFish in this.fish)
            {
                AnyFish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine("Fish: " + string.Join(", ", this.Fish.Select(x => x.Name)));
            }
            sb.AppendLine("Decorations: " + this.Decorations.Count);
            sb.AppendLine("Comfort: " + this.Comfort);

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            var neededFish = this.Fish.Where(x => x.Name == fish.Name).FirstOrDefault();

            if (neededFish == null)
            {
                return false;
            }

            this.fish.Remove(neededFish);
            return true;
        }
    }
}
