using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    class Cage
    {
        public Rabbit[] data;
        public string name;
        public int capacity;
        public int Count
        {
            get
            {
                int count = 0;

                for (int i = 0; i < this.data.Length; i++)
                {
                    if (this.data[i] != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public Rabbit[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }


        public Cage(string name, int capacity)
        {
            this.data = new Rabbit[capacity];
            this.name = name;
            this.capacity = capacity;
        }

        public void Add(Rabbit rabit)
        {
            IEnumerator enumerator = this.data.GetEnumerator();
            data[enumerator] = rabit;
        }

        public bool RemoveRabbit(string name)
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i].name == name)
                {
                    this.data[i] = null;
                    return true;
                }
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i].species == species)
                {
                    this.data[i] = null;
                }
            }
        }

        public Rabbit SellRabbit(string name)
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[1].name == name)
                {
                    this.data[1].available = false;
                    return this.data[1];
                }
            }
            return null;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> soldRabbits = new List<Rabbit>();

            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[1].species == species)
                {
                    soldRabbits.Add(this.data[1]);
                    this.data[1].available = false;
                }
            }

            return soldRabbits.ToArray();
        }

        //public int Count()
        //{
        //    int count = this.data.Length;
        //    return count;
        //}

        public string Report()
        {
            StringBuilder newSB = new StringBuilder();
            newSB.AppendLine($"Rabbits available at {this.name}:");
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i].available)
                {
                    newSB.AppendLine(data[i].ToString());
                }

            }
            return newSB.ToString().Trim();
        }
    }
}
