using AquaShop.Core.Contracts;
using AquaShop.Models;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Fish;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            string result = string.Empty;

            if(aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            this.aquariums.Add(aquarium);
            result = string.Format(OutputMessages.SuccessfullyAdded, aquariumType);

            return result;
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;
            string result = String.Empty;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            this.decorations.Add(decoration);
            result = string.Format(OutputMessages.SuccessfullyAdded, decorationType);

            return result;
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            string result = string.Empty;
            var neededAquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();

            IFish fish = null;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (neededAquarium.GetType().Name == "FreshwaterAquarium" && fishType == "FreshwaterFish")
            {
                neededAquarium.AddFish(fish);
                result = string.Format(OutputMessages.FishAdded, fishType, aquariumName);
            }
            else if (neededAquarium.GetType().Name == "SaltwaterAquarium" && fishType == "SaltwaterFish")
            {
                neededAquarium.AddFish(fish);
                result = string.Format(OutputMessages.FishAdded, fishType, aquariumName);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }

            return result;
        }

        public string CalculateValue(string aquariumName)
        {
            string result = string.Empty;
            var aquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();

            decimal fishPrice = aquarium.Fish.Sum(x => x.Price);
            decimal decorPrice = aquarium.Decorations.Sum(x => x.Price);
            decimal value = fishPrice + decorPrice;

            result = string.Format(OutputMessages.AquariumValue, aquariumName, value);

            return result;
        }

        public string FeedFish(string aquariumName)
        {
            int count = 0;
            string result = string.Empty;

            var aquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
                count++;
            }

            result = string.Format(OutputMessages.FishFed, count);

            return result;
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium = this.aquariums.Where(x => x.Name == aquariumName).FirstOrDefault();
            var decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            string result = string.Format(OutputMessages.DecorationAdded, decorationType, aquariumName);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("\"");
            foreach (var aquarium in this.aquariums)
            {
                sb.Append(aquarium.GetInfo() + Environment.NewLine);
            }
            sb.ToString().TrimEnd();
            //sb.Append("\"");

            return sb.ToString().Trim();
        }
    }
}
