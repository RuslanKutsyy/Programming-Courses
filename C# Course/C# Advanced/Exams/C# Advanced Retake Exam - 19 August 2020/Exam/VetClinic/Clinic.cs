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

            if (pet == null)
            {
                return false;
            }

            this.data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            var pet = this.data.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            var pet = this.data.OrderByDescending(p => p.Age).FirstOrDefault();
            return pet;
        }

        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.data)
            {
                sb.AppendLine(pet.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
