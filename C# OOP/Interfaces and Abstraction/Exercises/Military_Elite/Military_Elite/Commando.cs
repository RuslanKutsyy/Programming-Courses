using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
