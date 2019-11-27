using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Military_Elite
{
    public class Commando : ICommando
    {
        public List<Mission> Missions { get; set; }
        public string Corps { get; set; }
        public decimal Salary { get; set; }
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Commando(string id, string firstName, string lastName, decimal salary, string corps)
        {
            this.Missions = new List<Mission>();
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Salary = salary;
            this.Corps = corps;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.ID} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Missions:");

            foreach (var mission in Missions.Where(x => x.State == "inProgress"))
            {
                sb.AppendLine("  " + mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
