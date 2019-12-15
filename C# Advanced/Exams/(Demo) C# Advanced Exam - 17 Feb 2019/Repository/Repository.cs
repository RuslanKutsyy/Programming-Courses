using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private int currentId { get; set; }
        private Dictionary<int, Person> data { get; set; }
        public int Count
        {
            get { return this.data.Count; }
        }

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            if (person != null)
            {
                if (this.data.Count == 0)
                {
                    this.data.Add(0, person);
                    currentId++;
                }
                else
                {
                    this.data.Add(currentId, person);
                }
            }
        }

        public Person Get(int id)
        {
            if (this.data.ContainsKey(id))
            {
                return this.data[id];
            }
            return null;
        }

        public bool Update(int id, Person newPerson)
        {
            if (this.data.ContainsKey(id))
            {
                this.data[id] = newPerson;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id))
            {
                this.data.Remove(id);
                return true;
            }
            return false;
        }
    }
}
