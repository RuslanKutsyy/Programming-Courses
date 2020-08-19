using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data { get; set; }
        public int Capacity { get; set; }

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            var pet = this.data.FirstOrDefault(x => x.Name == name);

            return this.data.Remove(pet);
        }

        public Pet GetPet(string name, string owner)
        {
            return this.data.FirstOrDefault(p => p.Name == name && p.Owner == owner);
        }

        public Pet GetOldestPet()
        {
            return this.data.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public int Count
        {
            get => this.data.Count;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
