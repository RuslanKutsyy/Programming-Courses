using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private Dictionary<string, Astronaut> data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }


        public SpaceStation(string name, int capacity)
        {
            this.data = new Dictionary<string, Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public void Add(Astronaut astronaut)
        {
            if (astronaut != null && this.data.Count <= Capacity)
            {
                this.data.Add(astronaut.Name, astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (this.data.ContainsKey(name))
            {
                this.data.Remove(name);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut oldest = this.data.OrderByDescending(x => x.Value.Age).FirstOrDefault().Value;
            return oldest;
        }

        public Astronaut GetAstronaut(string name)
        {
            if (this.data.ContainsKey(name))
            {
                return this.data[name];
            }
            return null;
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var item in this.data)
            {
                string result = item.Value.ToString();
                sb.AppendLine(result);
            }

            return sb.ToString().Trim();
        }
    }
}
